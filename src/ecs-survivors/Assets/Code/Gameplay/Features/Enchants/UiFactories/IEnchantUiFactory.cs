using Code.Gameplay.Features.Enchants.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants.UiFactories
{
    public interface IEnchantUiFactory
    {
        Enchant CreateEnchant(Transform parent, EnchantTypeId typeId);
    }
}