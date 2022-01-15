using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PlayableCharacter : BaseCharacter
{
    [SerializeField] protected InventorySystem _inventory = null;
    [SerializeField] protected string _className;
    [SerializeField] protected PassiveAbility[] _passiveAbilities;//Abilities que aumentan los stats
    [SerializeField] protected ActiveAbility[] _activeAbilities;//Abilities que se activan con un input
    [SerializeField] protected AbilitySystem _abilitySystemReference;
    [SerializeField] protected LevelingSystem _levelingSystemReference;
    [SerializeField] protected const float experienceMultiplier = 1.5f;


    public virtual void SpecialAbility(int p_abilityIndex)//Abity index o ability ID ? ARREGLAR EN CADA UNO DE LAS CLASES DERIVADAS
    {
        //Acá selecciono mi array de habilidades activas, utilizo el índice y luego activo la habilidad
        //Quizás modificar el cooldown--->Active Ability 
    }

    public bool BuyAbility(int p_id)
    {
        return _abilitySystemReference.BuyAbility(p_id, _levelingSystemReference);//Regresa verdadero si se pudo comprar la habilidad
    }

    public bool AddAbilityFromAvailableList(int p_id)
    {
        AbilityNode newAbility = _abilitySystemReference.GetAbilityFromAvailableAbilities(p_id);
        AbilityData abilityLists = _abilitySystemReference.GetClassAbilities();

        bool wasAbilityAdded = false;

        if (newAbility.GetAbilityType() == AbilityNode.AbilityType.Passive)
        {
            foreach (PassiveAbility item in abilityLists.GetPassiveAbilities())
            {
                if (item.GetAbilityID() == newAbility.GetAbilityID())
                {
                    PassiveAbility passiveAbility = item;//Acá creo que es un poco al pedo agregarla así a otra variable

                    //Llamar al array de passive abilities y agregarla.

                    wasAbilityAdded = AddAbilityToArray(passiveAbility);
                }
            }
        }

        if (newAbility.GetAbilityType() == AbilityNode.AbilityType.SpecialMove)
        {
            foreach (ActiveAbility item in abilityLists.GetActiveAbilities())
            {
                if (item.GetAbilityID() == newAbility.GetAbilityID())
                {
                    ActiveAbility activeAbility = item;//Acá creo que es un poco al pedo agregarla así a otra variable

                    //Llamar al array de active abilities y agregarla.

                    wasAbilityAdded = AddAbilityToArray(activeAbility);
                }
            }
        }

        return wasAbilityAdded;
    }

    //string json;
    //json = System.IO.File.ReadAllText(Application.dataPath + "/PassiveStatsList.json");
    //SimpleJSON.JSONNode passiveAbilitiesData = SimpleJSON.JSON.Parse(json);

    //for (int i = 0; i < passiveAbilitiesData["passiveAbilitiesData"].AsArray.Count; i++)
    //{
    //    if (passiveAbilitiesData["passiveAbilitiesData"].AsArray[i]["passiveID"]== newPassiveAbility.GetAbilityID())
    //    {
    //        BaseCharacter.Stats newStats = passiveAbilitiesData["passiveAbilitiesData"].AsArray[i]["stats"];

    //        newPassiveAbility.SetPassiveStats(newStats);
    //    }
    //}

    //public List<AbilityNode> GetPurchasableAbilitiesList()
    //{
    //    return abilitySystemReference.GetPurchasableAbilitiesList();
    //}

    //public List<AbilityNode> GetAbilitiesAvailable()
    //{
    //    return abilitySystemReference.GetAvailableAbilitiesList();
    //}

    //public int GetActiveAbilityFromIndex(int index)//Este método debería devolverme algo para 
    //{
    //   return 
    //}
    private bool AddAbilityToArray(PassiveAbility _passiveAbility)
    {
        for (int i = 0; i < _passiveAbilities.Length; i++)
        {
            if (_passiveAbilities[i] == _passiveAbility)//Ya tengo agregada esta habilidad a mi array
            {
                return false;
            }
            if (_passiveAbilities[i] == null)//En esa posición no hay nada.
            {
                _passiveAbilities[i] = _passiveAbility;
                return true;
            }
        }
        return false;
    }

    private bool AddAbilityToArray(ActiveAbility _activeAbility)
    {
        for (int i = 0; i < _activeAbilities.Length; i++)
        {
            if (_activeAbilities[i] == _activeAbility)//En esa posición, mi nueva habilidad no es la misma que la que hay ahí.
            {
                return false;
            }
            if (_activeAbilities[i] == null)//En esa posición no hay nada.
            {
                _activeAbilities[i] = _activeAbility;
                return true;
            }
        }
        return false;
    }

    public void AddStatsFromEquipment()
    {
        BaseItem[] equipment = _inventory.GetEquipment();

        for (int i = 0; i < equipment.Length; i++)
        {
            if (equipment[i] != null)
            {
                SetMoreStats(equipment[i].GetStats());
            }
        }
    }

    public override void Die()
    {
        //Jajaj no se puede bro
        // Destroy(gameObject);
    }

    //No sé si lo voy a usar a esto todavía pero por si las dudas lo tengo creado 
    public void SetMoreStats(Stats moreStats)
    {
        _myStats._dmg += moreStats._dmg;

        _myStats._life += moreStats._life;

        _myStats._lifeCap += moreStats._lifeCap;

        _myStats._range += moreStats._range;

        _myStats._speed += moreStats._speed;

        Debug.Log(_myStats);
    }

    public void SetLessStats(Stats lessStats)
    {
        _myStats._dmg -= lessStats._dmg;

        _myStats._life -= lessStats._life;

        _myStats._lifeCap -= lessStats._lifeCap;

        _myStats._range -= lessStats._range;

        _myStats._speed -= lessStats._speed;
    }

    public void SetNewStats(Stats newStats)
    {
        _myStats = newStats;
    }

    public Stats GetStats()
    {
        return _myStats;
    }
    public InventorySystem GetInventory()
    {
        return _inventory;
    }
    public void SetInventory(InventorySystem newInventory)
    {
        _inventory = newInventory;
    }

    public string GetClassName()
    {
        return _className;
    }

    public void LevelUp()
    {
        _levelingSystemReference.LevelUp();
    }

    public PassiveAbility[] GetPassiveAbilities()
    {
        return _passiveAbilities;
    }

    public ActiveAbility[] GetActiveAbilities()
    {
        return _activeAbilities;
    }

    public List<AbilityNode> GetPurchasableAbilitiesList()
    {
        return _abilitySystemReference.GetPurchasableAbilities();
    }
    public List<AbilityNode> GetAvailableAbilitiesList()
    {
        return _abilitySystemReference.GetAvailableAbilities();
    }
}
