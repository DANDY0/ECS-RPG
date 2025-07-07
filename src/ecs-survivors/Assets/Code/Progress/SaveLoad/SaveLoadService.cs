using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "PlayerProgress" ;
        private readonly MetaContext _meta;
        private readonly IProgressProvider _progressProvider;
        private readonly ITimeService _timeService;

        public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);

        public SaveLoadService(MetaContext meta, IProgressProvider progressProvider, ITimeService timeService)
        {
            _meta = meta;
            _progressProvider = progressProvider;
            _timeService = timeService;
        }

        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData
            {
                LastSimulationTickTime = _timeService.UtcNow
            });
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();
            PlayerPrefs.SetString("PlayerProgress", _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();

        }

        public void LoadProgress()
        {
            string serializedProgress = PlayerPrefs.GetString(ProgressKey);
            HydrateProgress(serializedProgress);
        }

        private void HydrateProgress(string serializedProgress)
        {
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());

            HydrateMetaEntities();
        }

        private void HydrateMetaEntities()
        {
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.MetaEntitySnapshots;
            foreach (var snapshot in snapshots)
            { 
                _meta
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progressProvider.EntityData.MetaEntitySnapshots = _meta
                .GetEntities()
                .Where(RequestSave)
                .Select(e => e.AsSavedEntity())
                .ToList();
        }

        private bool RequestSave(MetaEntity metaEntity)
        {
            return metaEntity.GetComponents().Any(c => c is ISavedComponent);
        }
    }
}