using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private float _valueCrystal = 0.2f;
    //[SerializeField] private TestItem _item;
    [SerializeField] private Item _item;
    [SerializeField] private bool _useCrystal = true; // 0 - Cold. 1 -HOT
                                                      // float countdown = 0.0f;
    private void OnCollisionStay(Collision collision)
    {
        var otherObj = collision.gameObject;
        if (otherObj)
        {
            //_item = otherObj.GetComponent<TestItem>();
            _item = otherObj.GetComponent<Item>();
            if (_item && _item.GetValState() != 3 && _item.GetTextState() != "Испорчено")
            {
                var stateNow = _item.GetValState();
                float valstate = 0f;
                if (_useCrystal)
                {
                    valstate = Mathf.Lerp(stateNow, 2f, Time.deltaTime * _valueCrystal);
                }
                else
                {
                    valstate = Mathf.Lerp(stateNow, 0f, Time.deltaTime * _valueCrystal);

                }
                _item.UpdateStateNew(valstate);

            }
        }
    }
}

