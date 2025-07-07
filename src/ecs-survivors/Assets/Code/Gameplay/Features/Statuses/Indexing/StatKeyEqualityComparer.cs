using System;
using System.Collections.Generic;
using Code.Gameplay.Features.CharacterStats.Indexing;

namespace Code.Gameplay.Features.Statuses.Indexing
{
    public class StatKeyEqualityComparer : IEqualityComparer<StatKey>
    {
        public bool Equals(StatKey x, StatKey y)
        {
            return x.TargetId == y.TargetId && x.TypeId == y.TypeId; 
        }

        public int GetHashCode(StatKey obj)
        {
            return HashCode.Combine(obj.TargetId, (int)obj.TypeId);
        }
    }
}