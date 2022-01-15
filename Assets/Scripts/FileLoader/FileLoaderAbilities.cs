using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoaderAbilities
{
    private static FileLoaderAbilities _instance;

    private AbilityData _abilities = null;

    public static FileLoaderAbilities GetInstance()
    {
        if (_instance == null)
        {
            _instance = new FileLoaderAbilities();
        }

        return _instance;
    }

    public AbilityData LoadAbilityData(string path)
    {
        string jsonLoadAbilityData = System.IO.File.ReadAllText(path);
        _abilities = JsonUtility.FromJson<AbilityData>(jsonLoadAbilityData);

        return _abilities;
    }

}
