namespace Code.Infrastructure.View
{
    public abstract class EntityComponentRegistrar : EntityDependent, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();
    }
}