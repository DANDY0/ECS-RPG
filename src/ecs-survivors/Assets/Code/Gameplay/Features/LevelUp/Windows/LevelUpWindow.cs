using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class LevelUpWindow: BaseWindow
    {
        public Transform AbilityLayout;
        private IAbilityUiFactory _factory;
        private IAbilityUpgradeService _abilityUpgradeService;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(
            IAbilityUiFactory abilityFactory,
            IAbilityUpgradeService abilityUpgradeService,
            IStaticDataService staticDataService,
            IWindowService windowService)
        {
            _windowService = windowService;
            _staticDataService = staticDataService;
            _abilityUpgradeService = abilityUpgradeService;
            _factory = abilityFactory;
        }

        protected override void Initialize()
        {
            foreach (AbilityUpgradeOption upgradeOption in _abilityUpgradeService.GetUpgradeOptions())
            {
                var abilityLevel = _staticDataService.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);
                
                _factory.CreateAbilityCard(AbilityLayout)
                    .Setup(upgradeOption.Id, abilityLevel, OnSelected);
            }
        }

        private void OnSelected(AbilityId id)
        {
            CreateEntity.Empty()
                .AddAbilityId(id)
                .isUpgradeRequest = true;
            
            _windowService.Close(Id);
        }
    }
}