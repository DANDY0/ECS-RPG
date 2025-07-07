using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 at);
    }
}