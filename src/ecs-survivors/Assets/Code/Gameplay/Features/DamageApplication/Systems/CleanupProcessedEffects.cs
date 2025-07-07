using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class CleanupProcessedEffects: ICleanupSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private List<GameEntity> _buffer = new(32);

        public CleanupProcessedEffects(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.Processed));
        }
        public void Cleanup()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                effect.Destroy();
            }
        }
    }
}