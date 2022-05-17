using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    int _countMoney = 0;
    void Awake()
    {
        GlobalEventManager.OnMoneyUpdate += updateCountMoney;
    }

   public void updateCountMoney()
    {
        int count = 1;
        _countMoney += count;
        GetComponent<Text>().text = $"Money: {_countMoney}";
    }

     
}
