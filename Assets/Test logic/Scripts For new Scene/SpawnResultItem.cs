using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResultItem : MonoBehaviour
{

    [SerializeField] GameObject[] _resultItems;
  
    float money;
    [SerializeField] float _maxValMoney = 30f;
    GameObject _resultPrefab;
    
    void Awake()
    {
        EventManager.OnAddResultItem.AddListener(AddResult);
        money = Random.RandomRange(10, _maxValMoney);

        EventManager.OnRemoveResultItem.AddListener(DeleteResult);
    }

   private void AddResult()
    {
        
        _resultPrefab = Instantiate(_resultItems[Random.Range(0, _resultItems.Length)], transform.position, transform.rotation) as GameObject;
        EventManager.AddButtonSell(money);
    }

    private void DeleteResult()
    {
     
         Destroy(_resultPrefab.gameObject);
       
        
    }


}
