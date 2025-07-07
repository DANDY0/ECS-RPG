namespace Code.Gameplay.Features.Statuses
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId);
        GameEntity CreatePoisonStatus(StatusSetup setup, int producerId, int targetId);
    }
}