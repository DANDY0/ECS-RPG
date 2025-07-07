using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectEffectItemSystem : IExecuteSystem
    {
        private readonly IEffectsFactory _effectsFactory;
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public CollectEffectItemSystem(GameContext game, IEffectsFactory effectsFactory)
        {
            _effectsFactory = effectsFactory;
            _collected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collected,
                    GameMatcher.EffectSetups));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity collected in _collected)
            foreach (GameEntity hero in _heroes)
            foreach (EffectSetup effectSetup in collected.EffectSetups)
                _effectsFactory.CreateEffect(effectSetup, hero.Id, hero.Id);
        }
    }
}