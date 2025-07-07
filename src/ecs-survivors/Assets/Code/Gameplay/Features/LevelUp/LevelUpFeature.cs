using Code.Gameplay.Features.LevelUp.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelUp
{
    public class LevelUpFeature: Feature
    {
        public LevelUpFeature(ISystemFactory systems)
        {
            Add(systems.Create<OpenLevelUpWindowSystem>());
            Add(systems.Create<StopTimeOnLevelUpSystem>());

            Add(systems.Create<UpgradeAbilityonRequestSystem>());
            
            Add(systems.Create<StartTimeOnLevelUpSystem>());
            

            
            Add(systems.Create<FinalizeProcessedLevelUpsSystem>());
        }
    }
}