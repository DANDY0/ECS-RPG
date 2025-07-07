using Code.Common.Entity;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public class LevelUpService : ILevelUpService
    {
        private readonly IStaticDataService _staticDataService;

        public float CurrentExperience { get; private set; }
        public int CurrentLevel { get; private set; }
        public float ExperienceForLevelUp() => _staticDataService.ExperienceForLevel(CurrentLevel + 1);
        
        public LevelUpService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void AddExperience(float value) 
        {
            CurrentExperience += value;
            
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            if (CurrentLevel >= _staticDataService.MaxLevel())
                return;

            float experienceForLevel = _staticDataService.ExperienceForLevel(CurrentLevel + 1);
            
            if(CurrentExperience < experienceForLevel)
                return;

            CurrentExperience -= experienceForLevel;
            CurrentLevel++;

            CreateEntity.Empty()
                .isLevelUp = true;
            
            UpdateLevel();
        }
    }
}