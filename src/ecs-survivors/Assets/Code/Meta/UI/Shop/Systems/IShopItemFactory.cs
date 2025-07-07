using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Systems
{
    public interface IShopItemFactory
    {
        MetaEntity CreateShopItem(ShopItemId shopItemId);
    }
}