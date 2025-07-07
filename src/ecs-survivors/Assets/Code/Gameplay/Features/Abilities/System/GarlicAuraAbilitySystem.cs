using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
    public class GarlicAuraAbilitySystem : IExecuteSystem
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private List<GameEntity> _buffer = new(32);

        public GarlicAuraAbilitySystem(GameContext contextParameter, IArmamentsFactory armamentsFactory, IAbilityUpgradeService abilityUpgradeService)
        {
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _abilities = contextParameter.GetGroup(GameMatcher
                .AllOf(GameMatcher.GarlicAuraAbility)
                .NoneOf(GameMatcher.Active)    
            );
            
            _heroes = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Hero)    
            );

        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.GarlicAura);

                _armamentsFactory.CreteEffectAura(AbilityId.GarlicAura, hero.Id, level);

                ability.isActive = true;
            }
        }
    }
}