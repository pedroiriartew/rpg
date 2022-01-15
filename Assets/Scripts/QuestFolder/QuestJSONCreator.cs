using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestJSONCreator : MonoBehaviour
{
    private AbilityData _abilityList;

    private void Awake()
    {
        _abilityList = new AbilityData();
        string json = JsonUtility.ToJson(_abilityList);
        System.IO.File.WriteAllText(Application.dataPath + "/RogueAbilityList.json", json);
    }
}// Esto de arriba está hecho para la primera vez que estaba creando el JSON



////Quest quest = new Quest(); questData();
//AbilityNode ability = new AbilityNode();
//abilityData = new AbilityData();


////quest.questStages = new Stage[1] { new Stage() };

////print(quest);

////quest.questStages[0].stageObjectives = new Objective[1] { new Objective() };

//abilityData.abilityList = new List<AbilityNode>();

//abilityData.abilityList.Add(ability);

// Esto de arriba está hecho para la primera vez que estaba creando el JSON

