using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    private static CharacterCreator _instance = null;
    private PlayableCharacter _playerClass = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(_instance);
        }

    }

    public static CharacterCreator GetInstance()
    {
        return _instance;
    }

    public void SetClass(PlayableCharacter character)
    {
        _playerClass = character;
    }

    public PlayableCharacter GetClass()
    {
        return _playerClass;
    }
}
