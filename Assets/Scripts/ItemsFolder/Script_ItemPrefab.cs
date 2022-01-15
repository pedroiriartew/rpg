using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ItemPrefab : Interactable
{
    private BaseItem _baseItem = null;

    public override void Interact()
    {
        base.Interact();

        gameObject.SetActive(false);
    }

    public void Initialize(BaseItem item)
    {
        BaseItem auxItem = null;
        _baseItem = item;

        if (_baseItem.GetItemType() == BaseItem.ItemType.Consumable) { auxItem = new ConsumableItem(); }
        if (_baseItem.GetItemType() == BaseItem.ItemType.Temporary) { auxItem = new TemporaryItem(); }
        if (_baseItem.GetItemType() == BaseItem.ItemType.Equipable) { auxItem = new EquipableItem(); }
        if (_baseItem.GetItemType() == BaseItem.ItemType.Miscellaneous) { auxItem = new MiscellaneousItem(); }

        auxItem.SetIcon(item.GetIcon());
        auxItem.SetID(item.GetItemID());
        auxItem.SetItemType(item.GetItemType());
        auxItem.SetName(item.GetName());

        auxItem.SetResourcesDataPath(item.GetResourcesDataPath());//Recordar que hay que ajustar todos los data path en los Json, que creo que ya está hecho
        auxItem.SetStats(item.GetStats());

        _baseItem = auxItem;

        _baseItem.SetIcon(Resources.Load<Sprite>(item.GetResourcesDataPath()));
        gameObject.GetComponent<SpriteRenderer>().sprite = _baseItem.GetIcon();
    }

    public override BaseItem GetItem()
    {
        return _baseItem;
    }

    public override bool IsItem()//Esto es cuando el jugador interactua con uno dentro del juego
    {
        return true;
    }

    public void SetItem(BaseItem newItem)
    {
        _baseItem = newItem;
    }
}
