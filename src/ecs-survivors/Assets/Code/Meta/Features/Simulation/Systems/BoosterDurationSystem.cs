using Entitas;

namespace Code.Meta.Features.Simulation
{
    public class BoosterDurationSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _tick;

        public BoosterDurationSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);
            
            _boosters = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.GoldGainBoost,
                    MetaMatcher.Duration));
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _tick)
            foreach (MetaEntity boost in _boosters)
            {
                boost.ReplaceDuration(boost.Duration - tick.Tick);

                if (boost.Duration <= 0)
                    boost.isDestructed = true;
            }
        }
    }
}