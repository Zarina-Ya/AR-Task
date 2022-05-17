using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string _state;
    public float _valState;
    public TextMesh _textMesh;
    public TextMesh _textMeshIndex;
    [SerializeField] public int _index;
    [SerializeField] private Material _materialFirstState;
    private void Awake()
    {
        var allTexts = GetComponentsInChildren<TextMesh>();
        _textMesh = allTexts[0];
        _textMeshIndex = allTexts[1];
        allTexts[1].text = _index.ToString();
        RandomState();

    }
  
    public int GetIndex()
    {
        return _index;
    }
   
    public void RecoverSpoiledState()
    {
        UpdateStateText(3);
        _valState = 3;
        Invoke("ReturnState", 5f);
    }
    public void SetNewState()
    {
        Invoke("ReturnState", 5f);
    }
    public float GetValState()
    {
        return _valState;
    }

    public string GetTextState()
    {
        return _textMesh.text;
    }

 
    private void ReturnState()
    {
        if (_materialFirstState != null)
        {
            RandomState();
            GetComponent<Renderer>().material = _materialFirstState;
        }
    }
    private void RandomState()
    {

        int count = Random.Range(0, 3);// 0 - cold, 1- warm, 2 - hot, 3 - испорчено
        _valState = count;
        UpdateStateText(count);
    }

    private void UpdateStateText(int count)
    {
        switch (count)
        {
            case 0:
                _state = "Холодный";
                //_valState = count;
                break;
            case 1:
                _state = "Теплый";
                // _valState = count;
                break;
            case 2:
                _state = "Горячий";
                //_valState = count;
                break;
            case 3:
                _state = "Испорчено";
                break;
            default:
                break;

        }
        _textMesh.text = _state;
    }
  
    public void UpdateStateNew(float increment)
    {
        _valState = increment;
        Debug.Log($"_valState {_valState}");
        EventManager.SendTextUpdate(_valState);
        int a = Mathf.RoundToInt(_valState);
        UpdateStateText(a);


    }
}
