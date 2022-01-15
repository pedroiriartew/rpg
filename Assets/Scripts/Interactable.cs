using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //[SerializeField] protected float range = 2f;


    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, range);//Hace un rango para que se vea el editor, así es más fácil ajustarlo.
    //}

    public virtual void Interact()
    {
        //Debug.Log("Estoy interactuando!");
    }

    public abstract bool IsItem();

    public virtual BaseItem GetItem()
    {
        return new ConsumableItem();
    }
}
