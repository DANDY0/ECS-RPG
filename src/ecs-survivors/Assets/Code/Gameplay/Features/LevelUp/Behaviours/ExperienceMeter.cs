using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
    public class ExperienceMeter: MonoBehaviour
    {
        public Slider Progresbar;
        public Image Fill;

        public void  SetExperience(float heroExperience, float experienceForLevelUp)
        {
            Fill.type = Image.Type.Tiled;
            Progresbar.value = heroExperience / experienceForLevelUp;
        }
    }
}