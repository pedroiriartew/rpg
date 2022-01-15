using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Warrior : PlayableCharacter
{

    public Warrior()
    {
        _myStats._life = 50f;
        _myStats._lifeCap = 50f;
        _myStats._dmg = 150f;
        _myStats._speed = 5f;
        _myStats._range = 10f;
        _inventory = new InventorySystem();
        _className = "Warrior";

        _abilitySystemReference = new AbilitySystem(_className);
        _levelingSystemReference = new LevelingSystem();
        _passiveAbilities = new PassiveAbility[3];
        _activeAbilities = new ActiveAbility[3];
    }

    public override void SpecialAbility(int p_abilityIndex)
    {
        base.SpecialAbility(p_abilityIndex);
    }

    public override void Action()
    {
        //Acá vendría la mecánica principal de atacar.
    }

    public override void Move()
    {

    }

}
