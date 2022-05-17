
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    [SerializeField] float tireVal = 20;
    [SerializeField] int size = 2;
    [SerializeField] private int _indexItemMAX;
    private List<System.Tuple<string, int>> _resipe;
    float timerStart;
    [SerializeField] private Text _textTimer;
    private void Awake()
    {
       
       _resipe = new List<System.Tuple<string, int>>();
        timerStart = tireVal;
        _textTimer.text = timerStart.ToString();
        CreateDict();

        EventManager.OnAddNewRecipe.AddListener(addNewRecipe);

    }

    private void Update()
    {
        timerStart -= Time.deltaTime;
        _textTimer.text = timerStart.ToString();
        if(timerStart < 0)
        {
            _resipe.Clear();
            CreateDict();
            
            timerStart = tireVal;
        }
      
    }
    private void CreateDict()
    {
        Randomdict();
        UpdateText();
        EventManager.SendRecipeUpdate(_resipe);
       
    }

    private void UpdateText()
    {
        string tmp = null;
        foreach (var stat in _resipe)
        {
            Debug.Log(stat);

            tmp += stat;
        }
        GetComponent<Text>().text = $"{tmp})";
    }
    private void Randomdict()
    {
        List<int> bottles = new List<int>();

        AddRandomBottles(bottles);
      
        for(int i = 0; i < bottles.Count; i++)
        {
            string item1 = GetStateInString(Random.Range(0, 3));
            AddNewIngredient(item1, bottles[i]);
        
        }

    }

    private void AddRandomBottles(List<int> bottles)
    {
        while (bottles.Count != size)
        {
            var bottle = Random.Range(0, _indexItemMAX);
            if (!bottles.Contains(bottle))
            {
     
                bottles.Add(bottle);
            }
        }
    }
    private void AddNewIngredient(string state, int bottleindex)
    {
        _resipe.Add(System.Tuple.Create(state, bottleindex));
    }
    private string GetStateInString(int stateIndex)
    {
        switch (stateIndex)
        {
            case 0:
                return "Холодный";
                
            case 1:
               return "Теплый";
                
            case 2:
                return "Горячий";
       
                
        }
        return "";
    }

    private void addNewRecipe()
    {
        _resipe.Clear();
        CreateDict();

        timerStart = tireVal;
    }


    
}
