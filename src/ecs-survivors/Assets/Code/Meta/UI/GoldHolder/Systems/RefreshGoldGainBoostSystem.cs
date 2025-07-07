using System.Collections.Generic;
using Code.Meta.UI.GoldHolder.Service;
using Entitas;

namespace Code.Meta.UI.GoldHolder.Systems
{
    public class RefreshGoldGainBoostSystem : ReactiveSystem<MetaEntity>, IInitializeSystem
    {
        private readonly MetaContext _meta;
        private readonly IStorageUiService _storage;
        private readonly IGroup<MetaEntity> _boosters;
        private List<MetaEntity> _boostersBuffer = new List<MetaEntity>(4);

        public RefreshGoldGainBoostSystem(MetaContext meta, IStorageUiService storage) : base(meta)
        {
            _meta = meta;
            _storage = storage;

            _boosters = meta.GetGroup(MetaMatcher.GoldGainBoost);
        }

        public void Initialize() 
            => UpdateGoldGameBoost(_boosters.GetEntities(_boostersBuffer));

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context) 
            => context.CreateCollector(MetaMatcher.GoldGainBoost.AddedOrRemoved());

        protected override bool Filter(MetaEntity entity) => true;

        protected override void Execute(List<MetaEntity> boosters ) 
            => UpdateGoldGameBoost(boosters);

        private void UpdateGoldGameBoost(List<MetaEntity> boosters)
        {
            float goldGainBooster = 0f;

            foreach (var booster in boosters)
            {
                if (booster.hasGoldGainBoost)
                    goldGainBooster += booster.GoldGainBoost;
            }
            
            _storage.UpdateGoldGainBoost(goldGainBooster);
        }
    }
}