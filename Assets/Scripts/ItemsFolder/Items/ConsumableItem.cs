using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsumableItem : BaseItem
{
    public ConsumableItem()
    {
        _itemType = ItemType.Consumable;
    }


    public override bool ItemUse(PlayableCharacter character)
    {
        character.SetMoreStats(_itemStats);

        return true;
    }

    /*
     * Agarro los stats de este equipableItem
     * 
     */
}
