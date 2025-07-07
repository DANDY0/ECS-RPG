namespace Code.Gameplay.Features.Statuses
{
    public interface IStatusApplier
    {
        GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId);
    }
}