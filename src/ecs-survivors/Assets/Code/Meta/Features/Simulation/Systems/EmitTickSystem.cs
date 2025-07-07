using Code.Common.Entity;
using Code.Gameplay.Common.Time;

namespace Code.Meta.Features.Simulation
{
    public class EmitTickSystem: TimerExecuteSystem
    {
        private readonly float _interval;

        public EmitTickSystem(/*float interval,*/ ITimeService time): base(/*interval, */time)
        {
            _interval = /*interval*/ 1f;
        }

        protected override void Execute()
        {
            CreateMetaEntity.Empty()
                .AddTick(_interval);
        }
    }
}