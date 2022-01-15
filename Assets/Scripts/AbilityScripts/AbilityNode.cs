using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityData
{

    [SerializeField] private PassiveAbility[] _passiveAbilities;

    [SerializeField] private ActiveAbility[] _activeAbilities;

    public PassiveAbility[] GetPassiveAbilities()
    {
        return _passiveAbilities;
    }

    public ActiveAbility[] GetActiveAbilities()
    {
        return _activeAbilities;
    }
}


[System.Serializable]
public class AbilityNode
{
    public enum AbilityType
    {
        Passive,
        SpecialMove
    }

    [SerializeField]
    protected int _ID;

    [SerializeField]
    protected string _abilityName;

    [SerializeField]
    protected AbilityType _abilityType;

    [SerializeField]
    //Bool comprado o no
    protected bool _comprado = false;

    [SerializeField]
    //Costo de compra
    protected int _pointsToBuy = 1;

    [SerializeField]
    //Habilidad activada o no
    protected bool _isAbilityActive = false;

    [SerializeField]
    //Array de nodos que son los conseguidos al comprar.
    protected AbilityNode[] _abilityNodes;

    public bool GetComprado()
    {
        return _comprado;
    }

    public void SetComprado(bool newState)
    {
        _comprado = newState;
    }

    public int GetPointsToBuy()
    {
        return _pointsToBuy;
    }

    public bool GetIsAbilityActive()
    {
        return _isAbilityActive;
    }

    public int GetAbilityID()
    {
        return _ID;
    }

    public AbilityNode[] GetAbilityNodesArray()
    {
        return _abilityNodes;
    }

    public string GetAbilityName()
    {
        return _abilityName;
    }

    public AbilityType GetAbilityType()
    {
        return _abilityType;
    }
}
