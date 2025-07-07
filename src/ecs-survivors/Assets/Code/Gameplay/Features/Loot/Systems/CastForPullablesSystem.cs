using Code.Common.Extensions;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CastForPullablesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _looters;
        private readonly IPhysicsService _physicsService;
        private int _layerMask = CollisionLayer.Collectable.AsMask();
        private GameEntity[] _hitBUffer = new GameEntity[128];

        public CastForPullablesSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _looters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PickupRadius));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _looters)
            {
                for (int i = 0; i < LootInRadius(entity); i++)
                {
                    if (_hitBUffer[i].isPullable)
                    {
                        _hitBUffer[i].isPullable = false;
                        _hitBUffer[i].isPulling = true;
                    }
                }

                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            for (int i = 0; i < _hitBUffer.Length; i++)
            {
                _hitBUffer[i] = null;
            }
        }

        private int LootInRadius(GameEntity entity)
        {
            return _physicsService.CircleCastNonAlloc(entity.WorldPosition, radius: entity.PickupRadius,
                _layerMask, _hitBUffer);
        }
    }
}