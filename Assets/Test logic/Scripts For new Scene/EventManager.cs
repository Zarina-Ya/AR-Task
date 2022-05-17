using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<float> OnTextUpdate = new EventFloat();
     
    public static UnityEvent<List<Tuple<string,int>>> OnRecipeUpdate = new EventRecipe();


    public static UnityEvent OnAddResultItem = new UnityEvent();

    public static UnityEvent OnRemoveResultItem = new UnityEvent();

    public static UnityEvent OnAddNewRecipe = new UnityEvent();

    public static UnityEvent OnEndGame = new UnityEvent();

    public static UnityEvent<float> OnAddButtonSell = new EventFloat();

    public static UnityEvent<float> OnUpdateMoney = new EventFloat();





    public static void SendTextUpdate(float val)
    {
       OnTextUpdate.Invoke(val);
    }

    public static void SendRecipeUpdate(List<Tuple<string, int>> recipte)
    {
        OnRecipeUpdate.Invoke(recipte);
    }

    public static void AddNewRecipe()
    {
        OnAddNewRecipe.Invoke();
    }

    public static void AddResultItem()
    {
        OnAddResultItem.Invoke();
    }

    public static void RemoveResultItem()
    {
        OnRemoveResultItem.Invoke();
    }


    public static void EndGameEvent()
    {
        OnEndGame.Invoke();
    }

    public static void AddButtonSell(float money)
    {
        OnAddButtonSell.Invoke(money);
    }

    public static void UpdateMoney(float money)
    {
        OnUpdateMoney.Invoke(money);
    }
}

public class EventFloat : UnityEvent<float> { }
public class EventInt : UnityEvent<int> { }
public class EventRecipe : UnityEvent<List<Tuple<string, int>>> { }
