using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TemporaryItem : BaseItem
{
    public TemporaryItem()
    {
        _itemType = ItemType.Temporary;
    }

    public override bool ItemUse(PlayableCharacter character)
    {
        character.SetMoreStats(_itemStats);

        return true;
    }
}
