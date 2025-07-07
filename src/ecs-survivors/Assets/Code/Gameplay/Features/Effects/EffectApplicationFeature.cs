
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.DamageApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effects
{
    public class EffectFeature: Feature
    {

        public EffectFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveEffectsWithoutTargetSystem>());
            
            Add(systems.Create<ProcessDamageEffectSystem>());
            Add(systems.Create<ProcessHealEffectSystem>());
            
            Add(systems.Create<CleanupProcessedEffects>());
        }
    }   
}