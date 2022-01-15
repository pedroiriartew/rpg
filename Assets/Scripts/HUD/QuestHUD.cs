using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHUD : MonoBehaviour
{
    private static QuestHUD _instance = null;
    [SerializeField] private List<QuestSlot> _questSlots = null;
    [SerializeField] private GameObject _questUI = null;
    [SerializeField] private QuestSlot _slotPrefab = null;
    [SerializeField] private Transform _questLayout = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static QuestHUD GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _questSlots = new List<QuestSlot>();
        //Acá debería instanciar dinámicamente todo lo que tenga en las availableQuests
        PlayerSingleton.GetInstance().GetPlayer().OpenCloseQuests += OpenCloseQuestMenu;
    }

    public void RemoveQuestFromAvailable(QuestSlot _quest)
    {
        if (QuestManagerSystem.GetInstance().RemoveQuest(_quest.GetQuest().GetID()))
        {
            _questSlots.Remove(_quest);
            UpdateQuestUI();
        }
    }

    private void UpdateQuestUI()
    {
        bool questFound;
        for (int i = 0; i < QuestManagerSystem.GetInstance().GetAvailableQuests().Count; i++)
        {
            questFound = false;
            foreach (QuestSlot questSlot in _questSlots)
            {
                if (questSlot.GetQuest() == QuestManagerSystem.GetInstance().GetAvailableQuests()[i])
                {
                    questFound = true;
                }
            }

            if (!questFound)
            {
                //Debug.Log(QuestManagerSystem.GetInstance().GetAvailableQuests()[i].GetID());
                //Debug.Log(QuestManagerSystem.GetInstance().GetAvailableQuests()[i].IsQuestActive());
                //Debug.Log(!QuestManagerSystem.GetInstance().GetAvailableQuests()[i].IsFinished());

                if (QuestManagerSystem.GetInstance().GetAvailableQuests()[i].IsQuestActive() && !QuestManagerSystem.GetInstance().GetAvailableQuests()[i].IsFinished())
                {
                    _questSlots.Add(Instantiate(_slotPrefab, _questLayout));
                    _questSlots[i].SetQuest(QuestManagerSystem.GetInstance().GetAvailableQuests()[i]);
                    _questSlots[i].InitializeSlot();
                }
            }
            else
            {
                Debug.Log("Ya lo tengo");
                _questSlots[i].gameObject.SetActive(_questUI.activeSelf);
            }
        }
    }

    public void OpenCloseQuestMenu()//método que cargo en la acción del PlayerActor--> Input J
    {
        _questUI.SetActive(!_questUI.activeSelf);

        UpdateQuestUI();
    }

    public void RemoveCompletedQuest(int _questID)
    {
        for (int i = 0; i < _questSlots.Count; i++)
        {
            if (_questSlots[i].GetQuest().GetID() == _questID)
            {
                _questSlots.RemoveAt(i);
            }
        }
    }

}
