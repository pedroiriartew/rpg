using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    private Quest _quest = null;
    private Text _questText = null;

    private void Awake()
    {
        _questText = GetComponentInChildren<Text>();
    }

    public void SetQuest(Quest _quest)
    {
        this._quest = _quest;
    }

    public Quest GetQuest()
    {
        return _quest;
    }

    public void InitializeSlot()
    {
        _questText.text = _quest.GetQuestType().ToString() + "\n" + _quest.GetName();
    }

    public void Remove()
    {
        QuestHUD.GetInstance().RemoveQuestFromAvailable(this);
    }
}
