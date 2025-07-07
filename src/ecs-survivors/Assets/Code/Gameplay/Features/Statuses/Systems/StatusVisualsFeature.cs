using Code.Gameplay.Features.Enchants.Systems;
using Code.Gameplay.Features.Statuses.StatusVisual;
using Code.Gameplay.Features.Statuses.Systems.StatusVisual;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusVisualsFeature: Feature
    {
        public StatusVisualsFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyFreezeVisualsSystem>());
            Add(systems.Create<ApplyPoisonVisualsSystem>());
            
            Add(systems.Create<UnApplyPoisonVisualsSystem>());
            Add(systems.Create<UnApplyFreezeVisualsSystem>());
            
            Add(systems.Create<RemoveUnappliedEnchantFromHolder>());
        }
    }
}