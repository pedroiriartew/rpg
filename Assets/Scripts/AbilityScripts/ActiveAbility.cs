using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActiveAbility : AbilityNode
{
    [SerializeField]
    private float _abilityCooldown = 0.0f;

    public ActiveAbility()
    {
        _abilityType = AbilityType.SpecialMove;
    }

    public float GetAbilityCooldown()
    {
        return _abilityCooldown;
    }

}
