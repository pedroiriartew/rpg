using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassiveAbility : AbilityNode
{
    [SerializeField]
    private BaseCharacter.Stats _passiveStats;

    public PassiveAbility()
    {
        _abilityType = AbilityType.Passive;
    }

    //Esto utiliza el character a la hora de conseguir
    public BaseCharacter.Stats GetPassiveStats()
    {
        return _passiveStats;
    }

    public void SetPassiveStats(BaseCharacter.Stats newStats)
    {
        _passiveStats = newStats;
    }
}
