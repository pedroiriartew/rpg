using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //array de strings ?

    [TextArea(3, 3)]
    [SerializeField]
    private string[] _lines;

    public string ReturnLine(int lineIndex)
    {
        return _lines[lineIndex];
    }

    public string[] GetLinesArray()
    {
        return _lines;
    }
    //Opción de prequisitos de determinada quest


    //// int de prioridad
    //[SerializeField]
    //private int priority;

    ////está terminado
    //[SerializeField]
    //private bool isFinished;

    //public enum DialogueType
    //{
    //    Lineal,
    //    Cyclic,
    //    Random
    //}

    ////Ciclicamente, Lineal o aleatorio?
    //[SerializeField]
    //private DialogueType dialogueType;

}
