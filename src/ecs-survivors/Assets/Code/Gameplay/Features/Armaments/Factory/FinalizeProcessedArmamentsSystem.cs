using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class FinalizeProcessedArmamentsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        public FinalizeProcessedArmamentsSystem(GameContext contextParameter)
        {
            _armaments = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                armament.RemoveTargetCollectionComponents();
                armament.isDestructed = true;
            }
        }
    }
}