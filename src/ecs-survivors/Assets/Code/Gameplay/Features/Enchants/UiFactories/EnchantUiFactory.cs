using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.UiFactories
{
    public class EnchantUiFactory : IEnchantUiFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private const string EnchantPrefabPath = "UI/Enchants/Enchant";

        public EnchantUiFactory(IInstantiator instantiator, IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public Enchant CreateEnchant(Transform parent, EnchantTypeId typeId)
        {
            EnchantConfig config = _staticDataService.GetEnchantConfig(typeId);
            Enchant enchant = _instantiator.InstantiatePrefabForComponent<Enchant>
                (_assetProvider.LoadAsset(EnchantPrefabPath), parent);
            enchant.Set(config);

            return enchant;
        }
        
    }
}