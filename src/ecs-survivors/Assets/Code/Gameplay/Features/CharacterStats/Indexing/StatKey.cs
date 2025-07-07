namespace Code.Gameplay.Features.CharacterStats.Indexing
{
    public struct StatKey
    {
        public readonly int TargetId;
        public readonly Stats TypeId;

        public StatKey(int targetId, Stats typeId)
        {
            TargetId = targetId;
            TypeId = typeId;
        }
    }

}