﻿using Code.Common.Entity;
using Code.Common.EntityIndices;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats
{
    public class StatChangeSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _statOwners;

        public StatChangeSystem(GameContext game)
        {
            _game = game;

            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            foreach (Stats stat in statOwner.BaseStats.Keys)
            {
                statOwner.StatModifiers[stat] = 0;

                foreach (GameEntity statChange in _game.TargetStatChanges(stat, statOwner.Id)) 
                    statOwner.StatModifiers[stat] += statChange.EffectValue;
            }
        }

    }
}