using System;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectWhenNearSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _pullables;
        public float CloseDistance = 0.2f;


        public CollectWhenNearSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            
            _pullables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Pulling,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity pullable in _pullables)
            {
                if (Vector3.Distance(hero.WorldPosition, pullable.WorldPosition) <= CloseDistance)
                    pullable.isCollected = true;
            }
        }
    }
}