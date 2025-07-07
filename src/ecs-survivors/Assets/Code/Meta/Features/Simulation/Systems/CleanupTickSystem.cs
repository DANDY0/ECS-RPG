using System.Collections.Generic;
using Entitas;

namespace Code.Meta.Features.Simulation
{
    public class CleanupTickSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private List<MetaEntity> _buffer = new (1);

        public CleanupTickSystem(MetaContext meta)
        {
            _ticks = meta.GetGroup(MetaMatcher.Tick);
        }
        
        public void Cleanup()
        {
            foreach (MetaEntity tick in _ticks.GetEntities(_buffer))
            {
                tick.Destroy();
            }
        }
    }
}