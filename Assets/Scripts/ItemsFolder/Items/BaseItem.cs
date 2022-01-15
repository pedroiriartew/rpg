using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseItem
{
    [System.Serializable]
    public enum ItemType
    {
        Temporary = 1,
        Equipable = 2,
        Consumable = 3,
        Miscellaneous = 4
    }

    [SerializeField]
    protected int _itemID;

    [SerializeField]
    protected Sprite _icon = null;

    [SerializeField]
    protected BaseCharacter.Stats _itemStats;

    [SerializeField]
    protected string _name = null;

    [SerializeField]
    protected ItemType _itemType;

    [SerializeField]
    protected string _resourcesDataPath = null;

    public string GetResourcesDataPath()
    {
        return _resourcesDataPath;
    }

    public BaseCharacter.Stats GetStats()
    {
        return _itemStats;
    }

    public ItemType GetItemType()
    {
        return _itemType;
    }

    public void SetStats(BaseCharacter.Stats newStats)
    {
        _itemStats = newStats;
    }

    public abstract bool ItemUse(PlayableCharacter character);

    public string GetName()
    {
        return _name;
    }

    public Sprite GetIcon()
    {
        return _icon;
    }

    public int GetItemID()
    {
        return _itemID;
    }

    public void SetIcon(Sprite newIcon)
    {
        _icon = newIcon;
    }

    public void SetID(int newID)
    {
        _itemID = newID;
    }

    public void SetItemType(BaseItem.ItemType newItemType)
    {
        _itemType = newItemType;
    }

    public void SetName(string newName)
    {
        _name = newName;
    }

    public void SetResourcesDataPath(string newDataPath)
    {
        _resourcesDataPath = newDataPath;
    }

}
