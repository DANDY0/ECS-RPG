using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects
{
    public class EffectsFactory : IEffectsFactory
    {
        private readonly IIdentifierService _identifiers;

        public EffectsFactory(IIdentifierService identifiers) 
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId)
        {
            switch (effectSetup.EffectTypeId)
            {
                case EffectTypeId.Unknown:
                    break;
                case EffectTypeId.Damage:
                    return CreateDamage(producerId, targetId, effectSetup.Value);
                case EffectTypeId.Heal:
                    return CreateHeal(producerId, targetId, effectSetup.Value);
            }
            
            throw new Exception($"Effect with typeId: {effectSetup.EffectTypeId} does not exist");
        }

        public GameEntity CreateDamage(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isDamageEffect = true)
                .AddEffectValue(value)
                .AddProducerId(producerId)
                .AddTargetId(targetId) 
                ;
        }
        
        public GameEntity CreateHeal(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isEffect = true)
                    .With(x => x.isHealEffect = true)
                    .AddEffectValue(value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId) 
                ;
        }

    }
}