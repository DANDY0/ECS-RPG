﻿using Entitas;

namespace Code.Gameplay.Features.DamageApplication
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _game = game;
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DamageEffect,
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

                target.ReplaceCurrentHP(target.CurrentHP - effect.EffectValue);
                
                if(target.hasDamageTakenAnimator)
                    target.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}