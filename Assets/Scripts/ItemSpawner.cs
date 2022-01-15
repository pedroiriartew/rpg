using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Testing Script
public class ItemSpawner : Interactable
{
    [SerializeField] private NPCPrefab _npc;

    public override void Interact()
    {
        if (QuestManagerSystem.GetInstance().IsQuestActive(_npc.GetIDs()[0]))
        {
            int[] listOfQuestIDs = _npc.GetIDs();
            QuestManagerSystem.GetInstance().MarkObjective(listOfQuestIDs[0], listOfQuestIDs[1], listOfQuestIDs[2]);

            _npc.SetIDs(listOfQuestIDs[0], listOfQuestIDs[1], 1);
        }


        ItemGenerator.GetInstance().CreateItem();
    }

    public override bool IsItem()
    {
        return false;
    }
}
