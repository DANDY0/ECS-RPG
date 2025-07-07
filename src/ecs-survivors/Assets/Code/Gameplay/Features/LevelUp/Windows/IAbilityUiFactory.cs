using Code.Gameplay.Features.LevelUp.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public interface IAbilityUiFactory
    {
        AbilityCard CreateAbilityCard(Transform parent);
    }
}