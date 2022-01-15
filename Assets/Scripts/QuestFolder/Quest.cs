using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum QuestType
    {
        MainQuest,
        SideQuest
    }

    [SerializeField] private int _questID = 0;

    [SerializeField] private string _questName = "Default Quest";
    [SerializeField] private Stage[] _questStages;

    [SerializeField] private bool _isQuestFinished = false;
    [SerializeField] private bool _isQuestActive = false;

    [SerializeField] private QuestType _type;

    public Stage[] GetStageList()
    {
        return _questStages;
    }

    public bool IsFinished()
    {
        return _isQuestFinished;
    }

    public void SetQuestState(bool newState)
    {
        _isQuestFinished = newState;
    }

    public bool IsQuestActive()
    {
        return _isQuestActive;
    }

    public void SetQuestActive(bool _isQuestActive)
    {
        this._isQuestActive = _isQuestActive;
    }

    public string GetName()
    {
        return _questName;
    }

    public int GetID()
    {
        return _questID;
    }

    public QuestType GetQuestType()
    {
        return _type;
    }

    public bool isCompleted()
    {
        foreach (Stage item in _questStages)
        {
            if (!item.IsFinished())
            {
                return false;
            }
        }

        return true;
    }
}

[System.Serializable]
public class QuestData
{
    public List<Quest> questList;
}
