using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiscellaneousItem : BaseItem
{
    public MiscellaneousItem()
    {
        _itemType = ItemType.Miscellaneous;
    }

    public override bool ItemUse(PlayableCharacter character)
    {
        return true;
    }

    //Calculo que el equipableItem use va a ser una leve descripción del objeto
}
