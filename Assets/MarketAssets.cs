using System.Collections.Generic;
using Soomla.Store;
using UnityEngine;
using System.Collections;

public class MarketAssets : IStoreAssets {
    public int GetVersion()
    {
        return 0;
    }

    public VirtualCurrency[] GetCurrencies()
    {
        return new VirtualCurrency[]{};
    }

    public VirtualGood[] GetGoods()
    {
        return new VirtualGood[]{SUPPORT_BADGE};
    }

    public VirtualCurrencyPack[] GetCurrencyPacks()
    {
        return new VirtualCurrencyPack[]{};
    }

    public VirtualCategory[] GetCategories()
    {
        return new VirtualCategory[]{GENERAL_CATEGORY};
    }

    public static VirtualGood SUPPORT_BADGE = new SingleUseVG(
        "Support Me!",
        "If you like this game and want to show some support, buy this fancy badge", 
        "support_badge",
        new PurchaseWithMarket("support_badge", 0.99)
    );

    public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory("General", new List<string>{"SUPPORT_BADGE"});
}
