using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class RemoveUnappliedEnchantFromHolder : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _holders;

        public RemoveUnappliedEnchantFromHolder(GameContext game) : base(game)
        {
            _holders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnchantHolder));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.EnchantTypeId,
                    GameMatcher.UnApplied));

        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            foreach (var holder in _holders)
            {
                holder.EnchantHolder.RemoveEnchant(entity.EnchantTypeId);
            }
        }
    }
}