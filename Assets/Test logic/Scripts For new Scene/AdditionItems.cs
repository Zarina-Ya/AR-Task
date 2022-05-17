using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionItems : MonoBehaviour
{
    public TextMesh _thisText;
    int _thisIndex;
    [SerializeField]public List<System.Tuple<string, int>> _recipe = new List<System.Tuple<string, int>>();
    public static bool _testLogic = true;
 

    private void Awake()
    {
        _thisText = GetComponentInChildren<TextMesh>();
        _thisIndex = this.GetComponent<Item>().GetIndex();

       EventManager.OnRecipeUpdate.AddListener(AddRecipe);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        var obj = collision.gameObject;

        if (IsBottle(obj))
        {
           
            if (OtherAllreadyStarted()) return;
            StartCalculate();
            
            if (IsTrueBottle(obj))
            {
                Mix(obj);
            }
            else
            {
                Spoil(obj);
                StopCalculate();
            }
            
        }

      

    }


    private void OnCollisionExit(Collision collision)
    {
      
        StopCalculate();
    }

    private void Spoil(GameObject bottle)
    {
        bottle.GetComponent<Renderer>().material.color = Color.black;
        this.GetComponent<Renderer>().material.color = Color.black;

        bottle.GetComponent<Item>().RecoverSpoiledState();
        this.GetComponent<Item>().RecoverSpoiledState();

    }
    private void Mix(GameObject bottle)
    {
        bottle.GetComponent<Renderer>().material.color = Color.green;
        this.GetComponent<Renderer>().material.color = Color.red;
        EventManager.AddResultItem();
        bottle.GetComponent<Item>().SetNewState();
        this.GetComponent<Item>().SetNewState();
        EventManager.AddNewRecipe();
    }
    private bool IsTrueBottle(GameObject bottle)
    {
        return _recipe.Contains(System.Tuple.Create(_thisText.text, _thisIndex)) && _recipe.Contains(System.Tuple.Create(bottle.GetComponent<Item>().GetTextState(), bottle.GetComponent<Item>().GetIndex()));
    }
    private bool IsBottle(GameObject obj)
    {
        return obj.CompareTag("Items");
    }

    private static bool OtherAllreadyStarted()
    {
        
        return !_testLogic;
    }
    private static void StartCalculate()
    {
        _testLogic = false;
    }

    private static void StopCalculate()
    {
        _testLogic = true;
    }

    private void AddRecipe(List<System.Tuple<string, int>> recipe)
    {
        
        if(_recipe.Count > 0)
        {
            _recipe.Clear();
        }
        
        foreach (var item in recipe)
        {
            _recipe.Add(item);
         
        }
     
    }
}
