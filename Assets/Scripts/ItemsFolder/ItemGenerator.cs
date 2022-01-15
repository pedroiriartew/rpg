using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private Script_ItemPrefab _itemPrefab;

    private static ItemGenerator _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(_instance);
        }

    }

    public static ItemGenerator GetInstance()
    {
        return _instance;
    }


    public void CreateItem()
    {
        Script_ItemPrefab itemActor = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);

        itemActor.Initialize(LoadItemData(ReturnRandomItemType()));
    }

    public void CreateItem(Vector3 p_position)
    {
        Script_ItemPrefab itemActor = Instantiate(_itemPrefab, p_position, Quaternion.identity);

        itemActor.Initialize(LoadItemData(ReturnRandomItemType()));
    }

    private BaseItem.ItemType ReturnRandomItemType()
    {
        int random = Random.Range(0, 4);

        switch (random)
        {
            case 0:
                return BaseItem.ItemType.Consumable;
            case 1:
                return BaseItem.ItemType.Equipable;
            case 2:
                return BaseItem.ItemType.Temporary;
            case 3:
                return BaseItem.ItemType.Miscellaneous;
            default:
                return BaseItem.ItemType.Consumable;
        }
    }

    //Por ID
    public BaseItem LoadItemData(BaseItem.ItemType itemtype, int id)
    {
        return CreateItemByType(itemtype, id);
    }

    //De manera random
    public BaseItem LoadItemData(BaseItem.ItemType itemtype)
    {
        int random = Random.Range(0, 3);

        return CreateItemByType(itemtype, random);
    }

    private BaseItem CreateItemByType(BaseItem.ItemType itemtype, int index)
    {
        ItemCollection loadedItemList = FileLoaderItems.GetInstance().LoadItemsCollection();

        switch (itemtype)
        {
            case BaseItem.ItemType.Temporary:
                return loadedItemList.GetTemporaryItemList()[index];

            case BaseItem.ItemType.Equipable:
                return loadedItemList.GetEquipableItemList()[index];

            case BaseItem.ItemType.Consumable:
                return loadedItemList.GetConsumableItemList()[index];

            case BaseItem.ItemType.Miscellaneous:
                return loadedItemList.GetMiscellaneousItemList()[index];
            default:
                return loadedItemList.GetConsumableItemList()[index];
        }
    }


    //BaseItem loadedItem;
    //string jsonLoadItemData = File.ReadAllText(Application.dataPath + "/items.json");
    //SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonLoadItemData);

    //for (int i = 0; i < data["itemList"].AsArray.Count; i++)
    //{
    //    if (data["itemList"].AsArray[i]["itemID"] == id)
    //    {
    //        BaseItem itemAux = data["itemList"].AsArray[i];


    //        string itemType = data["itemList"].AsArray[i]["itemType"];
    //        BaseItem.ItemType type = (BaseItem.ItemType)int.Parse(itemType);//hypercast

    //        loadedItem = CreateItemByType(type);

    //        string statsString = data["itemList"].AsArray[i]["itemStats"];
    //        BaseCharacter.Stats newStats = (BaseCharacter.Stats)statsString;
    //        loadedItem.SetStats(newStats);
    //    }

    //BaseItem myItemData = new ConsumableItem();

    //string jsonSaveItemData = JsonUtility.ToJson(myItemData);

    //Debug.Log(jsonSaveItemData);

    //File.WriteAllText(Application.dataPath + "/items.json", jsonSaveItemData);


    //List<BaseItem> itemList = new List<BaseItem>();

    //for (int i = 0; i < data.Children.Count(); i++)
    //{

    //}

    //string itemTypeData = data["itemType"].Value;//Como si fuera un diccionario

    //BaseItem.ItemType type = (BaseItem.ItemType)int.Parse(itemTypeData);//hypercast

    //BaseItem loadedItem = CreateItemByType(type, jsonLoadItemData);
}
