using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSystem
{
    [SerializeField] private Dialogue[] _dialogue;

    public int dialogueIndex = 0;

    public string ActionDialogue(int lineIndex)//QuestID como parámetro y el segundo la línea.
    {
        return _dialogue[dialogueIndex].ReturnLine(lineIndex);
    }
}
