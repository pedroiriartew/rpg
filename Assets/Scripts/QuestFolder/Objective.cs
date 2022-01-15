using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{
    public enum ObjectiveType
    {
        Position,
        Items,
        Enemy,
        Npc
    }

    [SerializeField] private int _objectiveID = 0;

    [SerializeField] private string _objectiveName = "Default Objective";

    [SerializeField] private ObjectiveType _type = default;

    [SerializeField] private bool _isObjectiveFinished = false;

    public int GetID()
    {
        return _objectiveID;
    }

    public bool IsFinished()
    {
        return _isObjectiveFinished;
    }

    public void SetObjetiveState(bool newState)
    {
        _isObjectiveFinished = newState;
    }

    public ObjectiveType GetObjectiveType()
    {
        return _type;
    }

    public string GetName()
    {
        return _objectiveName;
    }
}

