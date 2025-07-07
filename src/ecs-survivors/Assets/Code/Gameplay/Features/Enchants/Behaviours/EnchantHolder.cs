using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UiFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder: MonoBehaviour
    {
        public Transform EnchantLayout;
         private IEnchantUiFactory _factory;
        private List<Enchant> _enchants = new();

        [Inject]
        private void Construct(IEnchantUiFactory factory) 
            => _factory = factory;

        public void AddEnchant(EnchantTypeId typeId)
        {
            if(EnchantAlreadyHeld(typeId))
                return;

            var enchant = _factory.CreateEnchant(EnchantLayout, typeId);

            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId typeId)
        {
            Enchant enchant =  _enchants.Find(x => x.Id == typeId);

            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }

        private bool EnchantAlreadyHeld(EnchantTypeId typeId)
        {
            return _enchants.Find(x=>x.Id == typeId) !=null;
        }
    }
}