using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScpt : MonoBehaviour
{
    public GameObject _prefab;
    public GameObject _instPrefab;
    public TextMesh _thisText;
    public Dictionary<string, int> _itms = new Dictionary<string, int>();



    
    private void Awake()
    {
        _thisText = GetComponentInChildren<TextMesh>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
       // Debug.Log(obj.name);


        if (obj && obj.CompareTag("Items"))
        {
           
            var text = obj.GetComponentInChildren<TextMesh>().text;
            Debug.Log(text);

            if(text == _thisText.text && text!= "Испорчено")
            {
                obj.GetComponent<Renderer>().material.color = Color.green;
                _instPrefab = Instantiate(_prefab, this.transform.position, this.transform.rotation) as GameObject;// Создается новый объект ResultItems

                GlobalEventManager.SendMoneyUpdate(); // вызов осбытия изменения монет 
                GlobalEventManager.SellButtonActive();// вызов осбытия изменения  кнопок

                Destroy(obj);
                Destroy(gameObject);
            }
            else
            {
                obj.GetComponent<Renderer>().material.color = Color.black;
            
                obj.GetComponent<TestItem>().SetState(3);
                GlobalEventManager.UpdateButtonActive();// вызов осбытия изменения  кнопок
            }
                


        }

    }

  

}
