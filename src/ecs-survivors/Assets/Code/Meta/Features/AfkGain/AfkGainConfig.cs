using UnityEngine;

namespace Code.Meta.Features.AfkGain
{
    [CreateAssetMenu(menuName = "ECS Survivors/Afk Gain Config", fileName = "AfkGainConfig")]
    public class AfkGainConfig: ScriptableObject
    {
        public float GoldPerSecond = 1;
    }
}