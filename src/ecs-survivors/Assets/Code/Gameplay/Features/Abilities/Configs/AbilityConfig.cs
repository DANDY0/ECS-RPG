using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(menuName = "ECS Survivors", fileName = "abilityConfig")]
    public class AbilityConfig: ScriptableObject
    {
        public AbilityId AbilityId;
        [FormerlySerializedAs("AbilityLevels")] public List<AbilityLevel> Levels;
    }
}