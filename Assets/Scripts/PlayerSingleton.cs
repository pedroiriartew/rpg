using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton
{
    private static PlayerSingleton _instance = null;
    private PlayerActor _player = null;

    public static PlayerSingleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new PlayerSingleton();
        }

        return _instance;
    }

    public void SetPlayer(PlayerActor _player)
    {
        this._player = _player;
    }

    public PlayerActor GetPlayer()
    {
        return _player;
    }
}
