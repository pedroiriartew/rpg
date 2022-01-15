using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MissionItem : Interactable
{

    [SerializeField] private MiscellaneousItem _missionItem = null;
    // Start is called before the first frame update
    private void Awake()
    {
        Initialize();
    }

    public override void Interact()
    {
        FindObjectOfType<NPCDummy>().SetHasSkull(true);
        _missionItem = null;
        Destroy(gameObject);
    }

    public override bool IsItem()
    {
        return true;
    }

    public override BaseItem GetItem()
    {
        return _missionItem;
    }

    private void Initialize()
    {
        _missionItem = FileLoaderItems.GetInstance().LoadItemsCollection().GetMiscellaneousItemList()[2];
        _missionItem.SetIcon(Resources.Load<Sprite>(_missionItem.GetResourcesDataPath()));
        gameObject.GetComponent<SpriteRenderer>().sprite = _missionItem.GetIcon();
    }
}
