using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManagerSystem
{
    private static QuestManagerSystem _instance = null;

    private List<Quest> _availableQuests;
    private List<Quest> _completedQuest;

    private QuestManagerSystem()
    {
        _availableQuests = new List<Quest>();
        _completedQuest = new List<Quest>();
    }

    public static QuestManagerSystem GetInstance()
    {
        if (_instance == null)
        {
            _instance = new QuestManagerSystem();
        }

        return _instance;
    }

    public void AddQuest(int p_IDquestToAdd)
    {
        string json = System.IO.File.ReadAllText(Application.dataPath + "/QuestDataList.json");
        QuestData questListData = JsonUtility.FromJson<QuestData>(json);

        foreach (Quest item in questListData.questList)
        {
            if (item.GetID() == p_IDquestToAdd)
            {
                item.SetQuestActive(true);
                _availableQuests.Add(item);
            }
        }
    }

    public bool RemoveQuest(int p_IDquestToRemove)//Esto es para no hacer las SideQuest
    {
        foreach (Quest item in _availableQuests)
        {
            if (item.GetID() == p_IDquestToRemove && item.GetQuestType() == Quest.QuestType.SideQuest)
            {
                //Acá puedo llamar a un evento del HUD para que no aparezca como Quest Activa o directamente desactivarlo de acá a razón de .SetActiveQuest(false);
                item.SetQuestActive(false);
                Debug.Log(item + "removido");
                _availableQuests.Remove(item);
                QuestHUD.GetInstance().RemoveCompletedQuest(p_IDquestToRemove);

                return true;
            }
        }

        return false;
    }

    public void MarkObjective(int questID, int stageID, int objectiveID)
    {
        foreach (Quest questItem in _availableQuests)
        {
            if (questItem.GetID() == questID)
            {
                foreach (Stage stageItem in questItem.GetStageList())
                {
                    if (stageItem.GetID() == stageID)
                    {
                        foreach (Objective objectiveItem in stageItem.GetObjectiveList())
                        {
                            if (objectiveItem.GetID() == objectiveID)
                            {
                                objectiveItem.SetObjetiveState(true);

                                if (stageItem.isCompleted())
                                {
                                    stageItem.SetStageState(true);

                                    if (questItem.isCompleted())
                                    {
                                        questItem.SetQuestState(true);
                                        _completedQuest.Add(questItem);
                                        questItem.SetQuestActive(false);
                                        _availableQuests.Remove(questItem);
                                        QuestHUD.GetInstance().RemoveCompletedQuest(questID);

                                        Debug.Log(questItem + " completed");

                                        PlayerSingleton.GetInstance().GetPlayer().GetCharacter().LevelUp();
                                    }
                                }
                                return;
                            }
                        }
                    }
                }
            }
        }
    }

    public List<Quest> GetAvailableQuests()
    {
        return _availableQuests;
    }

    public List<Quest> GetCompletedQuests()
    {
        return _completedQuest;
    }

    public bool IsQuestActive(int questID)
    {
        foreach (Quest item in _availableQuests)
        {
            if (item != null)
            {
                if (item.GetID() == questID)
                {
                    return item.IsQuestActive();
                }
            }
        }

        return false;
    }

    public bool IsQuestFinished(int questID)
    {
        foreach (Quest item in _completedQuest)
        {
            if (item != null)
            {
                if (item.GetID() == questID)
                {
                    return item.IsFinished();
                }
            }
        }

        return false;
    }

    public int ReturnCurrentObjectiveID(int questID)
    {
        foreach (Quest questItem in _availableQuests)
        {
            if (questItem.GetID() == questID)
            {
                foreach (Stage stageItem in questItem.GetStageList())
                {
                    if (!stageItem.IsFinished())
                    {
                        foreach (Objective objectiveItem in stageItem.GetObjectiveList())
                        {
                            if (!objectiveItem.IsFinished())
                            {
                                return objectiveItem.GetID();
                            }
                        }
                    }
                }
            }
        }

        Debug.LogError("Esta Quest no tiene un objetivo activo o la quest no está agregada");
        return -1;
    }
}

