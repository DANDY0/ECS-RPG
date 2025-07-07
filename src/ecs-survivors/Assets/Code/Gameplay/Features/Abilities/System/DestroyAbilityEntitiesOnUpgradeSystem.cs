using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
    public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _upgradeRequest;
        private readonly IGroup<GameEntity> _abilities;

        public DestroyAbilityEntitiesOnUpgradeSystem(GameContext game)
        {
            _game = game;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RecreatedOnUpgrade,
                    GameMatcher.AbilityId));
            
            _upgradeRequest = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityId));
        }

        public void Execute()
        {
            foreach (GameEntity request in _upgradeRequest)
            foreach (GameEntity ability in _abilities)
            {
                if (request.AbilityId == ability.AbilityId)
                {
                    foreach (var entity in _game.GetEntitiesWithParentAbility(ability.AbilityId)) 
                        entity.isDestructed = true;

                    ability.isActive = false;
                }
                
            }
        }
    }

}