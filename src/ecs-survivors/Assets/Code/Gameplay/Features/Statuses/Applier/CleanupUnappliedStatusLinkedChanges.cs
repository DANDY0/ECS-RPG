using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Applier
{
    public class CleanupUnappliedStatusLinkedChanges: ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _statuses;
        private List<GameEntity> _buffer = new(32);

        public CleanupUnappliedStatusLinkedChanges(GameContext game)
        {
            _game = game;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Status,
                    GameMatcher.UnApplied));
        }
 
        public void Cleanup()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            foreach (GameEntity entity in _game.GetEntitiesWithApplierStatusLink(status.Id))
            {
                entity.isDestructed = true;
            }
        }
    }
}