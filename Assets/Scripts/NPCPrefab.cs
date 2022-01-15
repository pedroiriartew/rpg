using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCPrefab : Interactable
{
    private FriendlyCharacter _npcScript;//Hacer algo con esto

    [SerializeField] private int[] _IDs;

    [SerializeField] private DialogueSystem _dialogueSystem;//Este dialogueSystem no se puede quitar de acá, tiene los strings que quedan

    public override bool IsItem()
    {
        return false;
    }

    public override void Interact()
    {
        base.Interact();

        if (!QuestManagerSystem.GetInstance().IsQuestActive(_IDs[0]) && !QuestManagerSystem.GetInstance().IsQuestFinished(_IDs[0]))
        {
            QuestManagerSystem.GetInstance().AddQuest(_IDs[0]);
        }

        GetComponentInChildren<Text>().text = _dialogueSystem.ActionDialogue(_IDs[2]);
    }

    public int[] GetIDs()
    {
        return _IDs;
    }

    public void SetIDs(int quest, int stage, int objective)
    {
        _IDs[0] = quest;
        _IDs[1] = stage;
        _IDs[2] = objective;
    }
}
