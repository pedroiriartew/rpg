using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sorcerer : PlayableCharacter
{
    public Sorcerer()
    {
        _myStats._life = 75;
        _myStats._lifeCap = 75;
        _myStats._dmg = 100;
        _myStats._speed = 5f;
        _myStats._range = 15f;
        _inventory = new InventorySystem();
        _className = "Sorcerer";

        _abilitySystemReference = new AbilitySystem(_className);
        _levelingSystemReference = new LevelingSystem();
        _passiveAbilities = new PassiveAbility[3];
        _activeAbilities = new ActiveAbility[3];
    }

    public override void SpecialAbility(int abilityIndex)
    {
        base.SpecialAbility(abilityIndex);
    }

    public override void Action()
    {
        //Acá vendría la mecánica principal de atacar.
    }
    public override void Move()
    {

    }
}
