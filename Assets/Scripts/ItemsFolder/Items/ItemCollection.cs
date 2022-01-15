using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemCollection
{
    [SerializeField] private EquipableItem[] _equipableItemList;

    [SerializeField] private ConsumableItem[] _consumableItemList;

    [SerializeField] private TemporaryItem[] _temporaryItemList;

    [SerializeField] private MiscellaneousItem[] _miscellaneousItemList;

    public ItemCollection()
    {
        _equipableItemList = new EquipableItem[1] { new EquipableItem() };

        _consumableItemList = new ConsumableItem[1] { new ConsumableItem() };

        _temporaryItemList = new TemporaryItem[1] { new TemporaryItem() };

        _miscellaneousItemList = new MiscellaneousItem[1] { new MiscellaneousItem() };
    }

    public EquipableItem[] GetEquipableItemList()
    {
        return _equipableItemList;
    }

    public ConsumableItem[] GetConsumableItemList()
    {
        return _consumableItemList;
    }

    public TemporaryItem[] GetTemporaryItemList()
    {
        return _temporaryItemList;
    }

    public MiscellaneousItem[] GetMiscellaneousItemList()
    {
        return _miscellaneousItemList;
    }

}
