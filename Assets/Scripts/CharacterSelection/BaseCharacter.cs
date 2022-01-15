using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase es la base de todos los personajes, tanto jugador como enemigos.

[System.Serializable]
public abstract class BaseCharacter
{
    [System.Serializable]
    public struct Stats
    {
        public float _dmg;
        public float _life;
        public float _lifeCap;
        public float _speed;
        public float _range;
        public float _actualExperience;
        public float _experienceCap;
    }

    [SerializeField]
    protected Stats _myStats;

    [SerializeField]
    protected DialogueSystem _dialogueSystem;

    public void ReceiveDmg(float p_damageReceived)
    {
        _myStats._life -= p_damageReceived;

        //Debug.Log("Recibiste dmg. Tenés " + _myStats._life);

        if (_myStats._life <= 0)
        {
            Die();
        }
    }

    public abstract void Die();//Esto se implementa en los scripts que heredan de este

    /*
        Los jugadores atacan, utilizan objetos e interactuan con NPCs. 
        Los NPCs otorgan misiones y hablan con los jugadores.
        Los enemigos atacan al jugador.
    */
    public abstract void Action();
    public abstract void Move();

    public float GetSpeed() { return _myStats._speed; }
    public float GetDamage() { return _myStats._dmg; }
    public float GetLife() { return _myStats._life; }
    public float GetCap() { return _myStats._lifeCap; }
    public float GetRange() { return _myStats._range; }

    public void CreateDialogueSystem()
    {
        _dialogueSystem = new DialogueSystem();
    }
}
