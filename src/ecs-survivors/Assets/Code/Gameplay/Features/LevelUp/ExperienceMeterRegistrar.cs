using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.View;
using UnityEngine.UIElements;

namespace Code.Gameplay.Features.LevelUp
{
    public class ExperienceMeterRegistrar: EntityComponentRegistrar
    {
        public ExperienceMeter ExperienceMeter;
        
        public override void RegisterComponents()
        {
            Entity.AddExperienceMeter(ExperienceMeter);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasExperienceMeter) 
                Entity.RemoveExperienceMeter();
        }
    }
}