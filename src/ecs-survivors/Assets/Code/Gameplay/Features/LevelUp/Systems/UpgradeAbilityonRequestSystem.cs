using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class UpgradeAbilityonRequestSystem : IExecuteSystem
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGroup<GameEntity> _upgradeRequest;
        private readonly IGroup<GameEntity> _levelUps;

        public UpgradeAbilityonRequestSystem(GameContext game, IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;

            _levelUps = game.GetGroup(GameMatcher.LevelUp);
            
            _upgradeRequest = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AbilityId,
                    GameMatcher.UpgradeRequest));
        }

        public void Execute()
        {
            foreach (GameEntity request in _upgradeRequest)
            foreach (GameEntity levelUp in _levelUps)
            {
                _abilityUpgradeService.UpgradeAbility(request.AbilityId);

                levelUp.isProcessed = true;
                request.isDestructed = true;
                
            }
        }
    }

}