using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication
{
    public class ApplyStatusesOnTargetsSystem: IExecuteSystem
    {
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.StatusSetups));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetID in entity.TargetsBuffer)
            foreach (StatusSetup setup in entity.StatusSetups)
            {
                _statusApplier.ApplyStatus(setup, ProducerId(entity), targetID);
            }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}