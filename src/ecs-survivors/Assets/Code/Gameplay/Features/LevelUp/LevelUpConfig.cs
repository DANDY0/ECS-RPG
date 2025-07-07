using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(menuName = "ECS Survivors/Level up onfig", fileName = "LevelUpConfig")]
    public class LevelUpConfig: ScriptableObject
    {
        public int MaxLevel;
        public List<float> ExperienceForLevel;
    }
}