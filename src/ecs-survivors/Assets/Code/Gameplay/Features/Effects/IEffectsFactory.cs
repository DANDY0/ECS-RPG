namespace Code.Gameplay.Features.Effects
{
    public interface IEffectsFactory
    {
        GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId);
        GameEntity CreateDamage(int producerId, int targetId, float value);
    }
}