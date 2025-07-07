using System;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        public ProcessHealEffectSystem(GameContext game)
        {
            _game = game;
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.HealEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                GameEntity target = _game.GetEntityWithId(effect.TargetId);

                effect.isProcessed = true;
                
                if(target.isDead)
                    continue;


                if (target.hasCurrentHP && target.hasMaxHP)
                {
                    var newValue = MathF.Min(target.CurrentHP + effect.EffectValue, target.MaxHP);
                    target.ReplaceCurrentHP(newValue); 
                }
                
            }
        }
    }
}