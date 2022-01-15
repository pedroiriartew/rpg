using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    private BaseItem _item = null;

    [SerializeField] private Image _icon;
    [SerializeField] private Button _removeButton;
    [SerializeField] private Transform _playerEquipment;
    private EquipmentSlotScript[] _equipmentSlots;
    private PlayableCharacter _character = null;


    private void Start()
    {
        _character = FindObjectOfType<PlayerActor>().GetCharacter();

        _equipmentSlots = _playerEquipment.GetComponentsInChildren<EquipmentSlotScript>();
    }

    public void AddItemToSlot(BaseItem newItem)
    {
        _item = newItem;

        _icon.sprite = _item.GetIcon();
        _icon.enabled = true;

        _removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;

        _removeButton.interactable = false;
    }

    public void UseItem()
    {
        if (_item != null)
        {
            bool wasItemSuccessfullyUsed = _item.ItemUse(_character);

            if (_item.GetItemType() == BaseItem.ItemType.Equipable)
            {
                if (wasItemSuccessfullyUsed)
                {
                    AssignToEquipmentSlot();
                    _character.AddStatsFromEquipment();
                }
            }

            if (_item.GetItemType() == BaseItem.ItemType.Temporary)
            {
                FindObjectOfType<PlayerActor>().SetTemporaryItemVariables(true, _item.GetStats());//Probablemente no es la mejor forma de hacerlo pero es la forma que encontré
            }

            if (wasItemSuccessfullyUsed) //Uso el item y lo quito del slot 
            {
                RemoveItem();
            }

        }
        else
        {
            Debug.Log("Algo salío muy mal, este Item está vacío");
        }
    }

    private void AssignToEquipmentSlot()
    {
        EquipableItem equipableItem = (EquipableItem)_item;

        ItemCollection itemData = FileLoaderItems.GetInstance().LoadItemsCollection();

        EquipableItem[] equipableItems = itemData.GetEquipableItemList();

        foreach (EquipableItem currentEquipItem in equipableItems)
        {
            if (equipableItem.GetItemID() == currentEquipItem.GetItemID())
            {
                equipableItem.SetEquipmentSlot(currentEquipItem.GetEquipmentSlot());
            }
        }

        if (equipableItem.GetEquipmentSlot() == InventorySystem.EquipableSlot.chest)
        {
            _equipmentSlots[0].AddItemToSlot(equipableItem);
            return;
        }

        if (equipableItem.GetEquipmentSlot() == InventorySystem.EquipableSlot.ring)
        {
            _equipmentSlots[1].AddItemToSlot(equipableItem);
            return;
        }

        if (equipableItem.GetEquipmentSlot() == InventorySystem.EquipableSlot.artifact)
        {
            _equipmentSlots[2].AddItemToSlot(equipableItem);
            return;
        }
    }

    public void RemoveItem()
    {
        InventorySystem inventory = FindObjectOfType<PlayerActor>().GetCharacter().GetInventory();

        inventory.RemoveFromInventory(_item);

        ClearSlot();
    }

}
