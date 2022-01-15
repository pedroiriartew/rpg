using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoaderItems
{
    private static FileLoaderItems _instance;

    private string _path = Application.dataPath + "/Items.json";

    private ItemCollection _itemsData = null;

    public static FileLoaderItems GetInstance()
    {
        if (_instance == null)
        {
            _instance = new FileLoaderItems();
        }

        return _instance;
    }

    public ItemCollection LoadItemsCollection()
    {
        string jsonLoadItemData = System.IO.File.ReadAllText(_path);
        _itemsData = JsonUtility.FromJson<ItemCollection>(jsonLoadItemData);

        return _itemsData;
    }

}
