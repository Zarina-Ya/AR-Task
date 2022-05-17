using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public Text text;
    float positionspawn = 0.25f;
    [SerializeField] private GameObject[] prefabs;

    private void Awake()
    {
       
    }
    public void QuitGame()
    {
        UpdateText();
        UpdateItems();
    }

    public void AddMoney()
    {
      
        GameObject[] objectItems;
        objectItems = GameObject.FindGameObjectsWithTag("ResultItems");

        if (objectItems != null)
        {
            foreach (GameObject items in objectItems)
            {
                text.text = "+Money";
                Destroy(items);

            }
        }

        GlobalEventManager.AddButtonActive();// вызов осбытия изменения  кнопок
    }
    public void AddItems()
    {
        var objectItems = GameObject.FindGameObjectsWithTag("Items");

        if (objectItems.Length == 0)
        {
            //foreach (var pr in prefabs)
            //{
            //    GameObject newPrefab = Instantiate(pr, new Vector3(positionspawn, 0f, 0f), Quaternion.identity);
            //    newPrefab.name = pr.name;
            //    positionspawn += 0.2f;
            //}
            GlobalEventManager.AddItems();// вызов осбытия изменения  кнопок

        }
        positionspawn = 0.25f;
    }

    public void UpdateText()
    {
        text.text = "Пока удалять вам нечего";
    }

    public void UpdateItems()
    {
        GameObject[] objectItems;
        objectItems = GameObject.FindGameObjectsWithTag("Items");

        if(objectItems != null)
        {
            foreach (GameObject items in objectItems)
            {
                var stateItem = items.GetComponent<TestItem>().GetTextState();
                if (stateItem == "Испорчено")
                {
                    text.text = $"Удаляем {items.gameObject.name}";
                    Destroy(items);
                }
            }
        }

        GlobalEventManager.AddButtonActive();// вызов осбытия изменения  кнопок
    }
}
