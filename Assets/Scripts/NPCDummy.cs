using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCDummy : Interactable
{
    [SerializeField] private DialogueSystem _dialogueSystem;
    private bool hasSkull = false;

    public override bool IsItem()
    {
        return false;
    }

    public override void Interact()
    {

        if (!QuestManagerSystem.GetInstance().IsQuestActive(0) && !hasSkull)
        {
            QuestManagerSystem.GetInstance().AddQuest(0);
            GetComponentInChildren<Text>().text = _dialogueSystem.ActionDialogue(QuestManagerSystem.GetInstance().ReturnCurrentObjectiveID(0));
            // Debug.Log(dialogueSystem.ActionDialogue(QuestManagerSystem.GetInstance().ReturnCurrentObjectiveID(0)));
            QuestManagerSystem.GetInstance().MarkObjective(0, 0, 0);

        }

        if (QuestManagerSystem.GetInstance().IsQuestActive(0) && hasSkull)
        {
            QuestManagerSystem.GetInstance().MarkObjective(0, 0, 1);
            GetComponentInChildren<Text>().text = _dialogueSystem.ActionDialogue(1);
            // Debug.Log(dialogueSystem.ActionDialogue(1));
        }

        if (!QuestManagerSystem.GetInstance().IsQuestActive(0) && hasSkull)
        {
            QuestManagerSystem.GetInstance().AddQuest(0);
            QuestManagerSystem.GetInstance().MarkObjective(0, 0, 0);
            QuestManagerSystem.GetInstance().MarkObjective(0, 0, 1);
            GetComponentInChildren<Text>().text = _dialogueSystem.ActionDialogue(1);
        }
    }

    public void SetHasSkull(bool _hasSkull)
    {
        hasSkull = _hasSkull;
    }

}
