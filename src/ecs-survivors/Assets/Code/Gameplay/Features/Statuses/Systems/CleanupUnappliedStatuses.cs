using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses
{
    public class CleanupUnappliedStatuses : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private List<GameEntity> _buffer = new List<GameEntity>(32);

        public CleanupUnappliedStatuses(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.UnApplied));
        }

        public void Cleanup()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer)) 
                status.isDestructed = true;
        }
    }
}