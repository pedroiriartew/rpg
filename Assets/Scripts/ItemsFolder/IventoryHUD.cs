using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryHUD : MonoBehaviour
{
    [SerializeField] private PlayerActor _player;
    [SerializeField] private Transform _playerBag;
    private SlotScript[] _bagSlots;
    private InventorySystem _playerInventory = null;
    [SerializeField] private GameObject _inventoryUI;

    private void Awake()
    {
        FindObjectOfType<PlayerActor>().OpenCloseInventory += OpenCloseInventory;
    }
    void Start()
    {
        _playerInventory = _player.GetCharacter().GetInventory();
        _playerInventory.AddedRemovedItem += UpdateUI;//Agrego mi set de instrucciones a UpdateUI

        _bagSlots = _playerBag.GetComponentsInChildren<SlotScript>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _bagSlots.Length; i++)
        {
            if (i < _playerInventory.GetAmountOfItemsInInventory())
            {
                _bagSlots[i].AddItemToSlot(_playerInventory.GetItem(i));
            }
            else
            {
                _bagSlots[i].ClearSlot();
            }
        }
    }

    public void OpenCloseInventory()
    {
        _inventoryUI.SetActive(!_inventoryUI.activeSelf);//Forma fancy de decirle ponete en el estado opuesto al que estás
    }
}
