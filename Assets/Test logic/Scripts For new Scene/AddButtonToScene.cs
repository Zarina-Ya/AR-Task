using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtonToScene : MonoBehaviour
{
    bool _active = false;
    float _moneyResult;
 
    void Start()
    {
        this.gameObject.SetActive(_active);
        //Подписываемся на Event вывода результата 
        EventManager.OnAddButtonSell.AddListener(UpdateActive);

    }

   
    private void UpdateActive(float money)
    {
        _active = true;
        this.gameObject.SetActive(_active);
        _moneyResult = money;
        Time.timeScale = 0;

    }

   
    public void UpdateMoney()
    {
        
        EventManager.UpdateMoney(_moneyResult);
        _active = false;
        this.gameObject.SetActive(_active);
        Time.timeScale = 1;
        EventManager.RemoveResultItem();
    }

    
}
