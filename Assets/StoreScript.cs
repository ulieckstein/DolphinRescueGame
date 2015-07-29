using Soomla.Store;
using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour {

    public void BuySupportBadge()
    {
        StoreInventory.BuyItem("support_badge");
    }
}
