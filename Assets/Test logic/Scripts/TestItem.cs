using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour
{
    public string _state;
    public float _valState;
    TextMesh _textMesh;
    [SerializeField] public int _index;
    private void Awake()
    {
        _textMesh = GetComponentInChildren<TextMesh>();
        RandomState();
        
    }

    public int GetIndex()
    {
        return _index;
    }
    public void SetState(int val)
    {
        UpdateStateText(val);
        _valState = val;
    }
    public float GetValState()
    {
        return _valState;
    }

    public string GetTextState()
    {
        return _textMesh.text;
    }
    private void RandomState()
    {
        
        int count = Random.Range(0,3);// 0 - cold, 1- warm, 2 - hot, 3 - испорчено
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
                break ;
            default:
                break;

        }
        _textMesh.text = _state;
    }
    //public void UpdateState(float increment)
    //{
    //    _valState += increment;
    //    Debug.Log($"_valState {_valState}");
    //   if(_valState < 0)
    //    {
    //        _valState = 0;
    //        UpdateStateText(0);
    //        return;
    //    }
    //   else if(_valState > 2)
    //    {
    //        _valState = 2;
    //        UpdateStateText(2);
    //        return;
    //    }
    
    //    else { 
    //        int a = Mathf.RoundToInt(_valState);
    //        if (a == 1 || a == 2 || a == 0)
            
    //            UpdateStateText(a);
    //    }

    //}

    public void UpdateStateNew(float increment)
    {
        _valState = increment;
        Debug.Log($"_valState {_valState}");
        
            int a = Mathf.RoundToInt(_valState);
            UpdateStateText(a);
        

    }
}
