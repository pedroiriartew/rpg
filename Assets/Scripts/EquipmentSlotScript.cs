using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotScript : MonoBehaviour
{
    private EquipableItem _equipableItem = null;

    [SerializeField] private Image _icon;

    [SerializeField] private Button _removeButton;

    private PlayableCharacter _character = null;


    private void Start()
    {
        _character = FindObjectOfType<PlayerActor>().GetCharacter();
    }

    public void AddItemToSlot(EquipableItem newEquipableItem)
    {
        _equipableItem = newEquipableItem;

        _icon.sprite = _equipableItem.GetIcon();
        _icon.enabled = true;

        _removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _equipableItem = null;

        _icon.sprite = null;
        _icon.enabled = false;

        _removeButton.interactable = false;
    }

    public void RemoveFromSlot()
    {
        _character.SetLessStats(_equipableItem.GetStats());
        _character.GetInventory().RemoveItemFromEquipment(_equipableItem);

        ClearSlot();
    }

}
