using Code.Gameplay.Features.Statuses.Applier;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusFeature: Feature
    {
        public StatusFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatusDurationSystem>());
            Add(systems.Create<PeriodicDamageStatusSystem>());
            Add(systems.Create<ApplyFreezeStatusSystem>());

            Add(systems.Create<StatusVisualsFeature>());

            Add(systems.Create<CleanupUnappliedStatusLinkedChanges>());
            Add(systems.Create<CleanupUnappliedStatuses>());
        }
    }
}