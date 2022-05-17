using System;

using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static Action OnMoneyUpdate;
    public static Action OnSellButtonActive;
    public static Action OnUpdateButtonActive;
    public static Action OnAddButtonActive;

    public static Action OnAddItems;
    public static void SendMoneyUpdate()
    {
        if (OnMoneyUpdate != null) OnMoneyUpdate.Invoke();
    }

    public static void SellButtonActive()
    {
        if(OnSellButtonActive != null) OnSellButtonActive.Invoke();
    }

    public static void UpdateButtonActive()
    {
        if (OnUpdateButtonActive != null) OnUpdateButtonActive.Invoke();
    }

    public static void AddButtonActive()
    {
        if (OnAddButtonActive != null) OnAddButtonActive.Invoke();
    }

    public static void AddItems()
    {
        if (OnAddItems != null) OnAddItems.Invoke();
    }
}
