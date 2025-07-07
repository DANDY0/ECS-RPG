using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public interface IStorageUiService
    {
        event Action GoldChanged;
        float CurrentGold { get; }
        float GoldGainBoost { get; }
        void UpdateCurrentGold(float gold);
        void Cleanup();
        void UpdateGoldGainBoost(float boost);
        event Action GoldBoostChanged;
    }
}