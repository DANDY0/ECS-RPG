using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public sealed class ArmamentFeature: Feature
    {
        public ArmamentFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkProcessedOnTargetLimitExceededSystem>());
            Add(systems.Create<FinalizeProcessedArmamentsSystem>());
            Add(systems.Create<FollowProducerSystem>());
        }
    }
}