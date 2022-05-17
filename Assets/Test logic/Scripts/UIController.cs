using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _updateButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _addItemButton;
    // Start is called before the first frame update
    void Awake()
    {
        _sellButton.gameObject.SetActive(false);
        _addItemButton.gameObject.SetActive(false);
        _updateButton.gameObject.SetActive(false);  
        GlobalEventManager.OnSellButtonActive += setActiveSellButton;
        GlobalEventManager.OnUpdateButtonActive += setActiveUpdateButton;
        GlobalEventManager.OnAddButtonActive += setActiveAddButton;
    }

   

    private void setActiveSellButton()
    {
        _sellButton.gameObject.SetActive(true);
    }
    private void setActiveUpdateButton()
    {
        _updateButton.gameObject.SetActive(true);
    }

    private void setActiveAddButton()
    {
        _addItemButton.gameObject.SetActive(true);
    }

}
