using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage
{
    [SerializeField] private int _stageID = 0;

    [SerializeField] private string _stageName = "Default Stage";

    [SerializeField] private bool _isStageFinished = false;

    [SerializeField] private Objective[] _stageObjectives;

    public Objective[] GetObjectiveList()
    {
        return _stageObjectives;
    }

    public int GetID()
    {
        return _stageID;
    }

    public bool IsFinished()
    {
        return _isStageFinished;
    }

    public void SetStageState(bool _StageState)
    {
        _isStageFinished = _StageState;
    }

    public string GetName()
    {
        return _stageName;
    }

    public bool isCompleted()
    {
        foreach (Objective item in _stageObjectives)
        {
            if (!item.IsFinished())
            {
                return false;
            }
        }

        return true;
    }
}
