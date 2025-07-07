using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Applier
{
    public class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IEffectsFactory _effectsFactory;
        private readonly IGroup<GameEntity> _statuses;
        
        public PeriodicDamageStatusSystem(GameContext game, ITimeService timeService, IEffectsFactory effectsFactory)
        {
            _timeService = timeService;
            _effectsFactory = effectsFactory;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Period,
                    GameMatcher.TimeSinceLastTick,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.TimeLeft >= 0)
                    status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _timeService.DeltaTime);
                else
                {
                    status.ReplaceTimeSinceLastTick(status.Period);
                    _effectsFactory.CreateEffect(
                        new EffectSetup { EffectTypeId = EffectTypeId.Damage, Value = status.EffectValue },
                        status.ProducerId,
                        status.TargetId);
                }
                
            }
        }
    }
}