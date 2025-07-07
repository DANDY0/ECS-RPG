using UnityEngine;

namespace Code.Gameplay.Features.Loot
{
    public interface ILootFactory
    {
        GameEntity CreateLootItem(LootTypeId typeId, Vector3 at);
    }
}