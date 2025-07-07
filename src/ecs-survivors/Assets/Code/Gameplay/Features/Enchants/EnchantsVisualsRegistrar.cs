using Code.Gameplay.Common.Visuals.Enchants;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class EnchantsVisualsRegistrar: EntityComponentRegistrar
    {
        public EnchantVisuals EnchantVisuals;  

        public override void RegisterComponents()
        {
            Entity.AddEnchantVisuals(EnchantVisuals);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnchantVisuals)
                Entity.RemoveEnchantVisuals();
        }
    }
}