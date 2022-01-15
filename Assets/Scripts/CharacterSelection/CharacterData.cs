using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    [SerializeField]
    private string _characterClass;

    [SerializeField]
    private BaseCharacter.Stats _characterStats;

    [SerializeField]
    private InventorySystem _characterInventory;

    public void SetData(BaseCharacter.Stats p_newStats, InventorySystem p_newInventory, string p_newCharacterClass)
    {
        _characterStats = p_newStats;
        _characterInventory = p_newInventory;
        _characterClass = p_newCharacterClass;
    }

    public BaseCharacter.Stats GetDataStats()
    {
        return _characterStats;
    }

    public InventorySystem GetDataInventory()
    {
        return _characterInventory;
    }

    public string GetDataCharacterClass()
    {
        return _characterClass;
    }
}
