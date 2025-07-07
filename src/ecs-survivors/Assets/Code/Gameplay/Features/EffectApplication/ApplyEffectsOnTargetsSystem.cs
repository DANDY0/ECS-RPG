using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication
{
    public class ApplyEffectsOnTargetsSystem: IExecuteSystem
    {
        private readonly IEffectsFactory _effectsFactory;
        private readonly IGroup<GameEntity> _entities;

        public ApplyEffectsOnTargetsSystem(GameContext game, IEffectsFactory effectsFactory)
        {
            _effectsFactory = effectsFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.EffectSetups));
        }
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetID in entity.TargetsBuffer)
            foreach (var setup in entity.EffectSetups)
            {
                _effectsFactory.CreateEffect(setup, ProducerId(entity), targetID);
            }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}