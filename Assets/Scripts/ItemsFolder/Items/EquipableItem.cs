using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipableItem : BaseItem
{
    [SerializeField] private InventorySystem.EquipableSlot _slotType;//Estos tienen serialize Field para que puedan ser guardados y leídos en el JSON

    public EquipableItem()
    {
        _itemType = ItemType.Equipable;
    }

    public override bool ItemUse(PlayableCharacter character)
    {
        ItemCollection itemData = FileLoaderItems.GetInstance().LoadItemsCollection();

        EquipableItem[] equipableItems = itemData.GetEquipableItemList();

        foreach (EquipableItem equipableItem in equipableItems)
        {
            if (GetItemID() == equipableItem.GetItemID())
            {
                SetEquipmentSlot(equipableItem.GetEquipmentSlot());
            }
        }

        return character.GetInventory().AddToEquipment(this);//True-->The item was added to the equipment
    }

    public InventorySystem.EquipableSlot GetEquipmentSlot()
    {
        return _slotType;
    }

    public void SetEquipmentSlot(InventorySystem.EquipableSlot newSlot)
    {
        _slotType = newSlot;
    }

    /*
     * Esta clase tiene que mantener los stats incrementados siempre y cuando este equipada dentro de el inventario.
     * Osea tengo que simplemente agregar este objeto al array de Equipables del inventario.
     * Se supone que el inventario o el PC se encarga de sumar los stats de ese array a los stats del jugador.
     * Creo que entonces ese array debería estar constantemente en 0, no sé como
     */

}