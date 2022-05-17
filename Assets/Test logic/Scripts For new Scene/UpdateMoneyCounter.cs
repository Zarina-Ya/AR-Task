using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoneyCounter : MonoBehaviour
{
    [SerializeField] private float _countMoney = 0;

    [SerializeField] private float _maxValMoney = 40;
    [SerializeField]  Text _childComp;
    [SerializeField] Text _parentComp;
    private void Awake()
    {
        EventManager.OnUpdateMoney.AddListener(UpdateMoney);
        _childComp.text = $"Монет необходимо собрать: {_maxValMoney}";
        _parentComp = GetComponent<Text>();
    }


    private void UpdateMoney(float money)
    {
        _countMoney += money;
        if (_countMoney >= _maxValMoney)
        {
            EventManager.EndGameEvent();
        }
        else
        {
            //Вызовем Event на окончание игры

            _parentComp.text = $"Монет: {Mathf.Round(_countMoney)}";
            _childComp.text = $"Монет необходимо собрать: {_maxValMoney}";
        }
      
       
    }
}
