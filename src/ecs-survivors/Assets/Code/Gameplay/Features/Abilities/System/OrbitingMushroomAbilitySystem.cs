using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.System
{
    public class OrbitingMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private List<GameEntity> _buffer = new(1);
        
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;

        public OrbitingMushroomAbilitySystem(GameContext game, IStaticDataService staticDataService,
            IArmamentsFactory armamentsFactory, IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitalMushroomAbility,
                    GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.OrbitingMushroom);
                
                AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, 1);
                var projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;

                for (int i = 0; i < projectileCount; i++)
                {
                    var phase = (2 * Mathf.PI * i) / projectileCount;
                    CreateProjectile(hero, phase, level);
                }
                
                ability
                    .PutOnCooldown(abilityLevel.Cooldown);
            }
        }

        private void CreateProjectile(GameEntity hero, float phase, int level)
        {
            _armamentsFactory.CreateMushroom(level, hero.WorldPosition + Vector3.up, phase)
                .AddProducerId(hero.Id)
                .AddOrbitCenterPosition(hero.WorldPosition)
                .AddOrbitCenterFollowTarget(hero.Id)
                .isMoving = true;
            ;
        }
    }
}