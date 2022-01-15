using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private BaseItem[] _playerBag = new BaseItem[10];
    [SerializeField] private BaseItem[] _playerEquipment = new BaseItem[3];

    [SerializeField] private int _amountOfItemsInBag = 0;

    public event Action AddedRemovedItem;

    public enum EquipableSlot
    {
        chest = 0,
        ring = 1,
        artifact = 2
    }

    public BaseItem[] GetEquipment()
    {
        return _playerEquipment;
    }

    public bool AddToInventory(BaseItem item)
    {
        for (int i = 0; i < _playerBag.Length; i++)
        {
            if (_playerBag[i] == null)
            {
                _playerBag[i] = item;

                _amountOfItemsInBag++;

                AddedRemovedItem?.Invoke();//Si mi evento AddedItem no es nulo, lo invoco

                return true;
            }
        }
        //Acá llamar a un UI con un texto que diga que no tengo espacio para agregar este objeto

        Debug.Log("No tienes más espacio en el inventario para agregar este objeto.");
        return false;
    }

    public bool AddToEquipment(EquipableItem item)
    {
        switch (item.GetEquipmentSlot())
        {
            case EquipableSlot.chest:

                if (_playerEquipment[0] == null)
                {
                    _playerEquipment[0] = item;
                    return true;
                }
                else
                {
                    //AddToInventory(playerEquipment[0]);//Agarro el equipableItem que ya está en mi slot y lo pongo en mi inventario (ESTÁ COMENTADO PORQUE NO VA MÁS PERO NO LO QUIERO PERDER 
                    _playerEquipment[0] = item;
                    return false;
                }

            case EquipableSlot.ring:

                if (_playerEquipment[1] == null)
                {
                    _playerEquipment[1] = item;
                    return true;
                }
                else
                {
                    _playerEquipment[1] = item;
                    return false;
                }

            case EquipableSlot.artifact:

                if (_playerEquipment[2] == null)
                {
                    _playerEquipment[2] = item;
                    return true;
                }
                else
                {
                    _playerEquipment[2] = item;
                    return false;
                }
            default:
                return false;
        }
    }

    public void RemoveItemFromEquipment(EquipableItem item)
    {
        if (item.GetEquipmentSlot() == EquipableSlot.chest)
        {
            AddToInventory(_playerEquipment[0]);//Agarro el equipableItem que ya está en mi slot y lo pongo en mi inventario
            _playerEquipment[0] = null;
            return;
        }

        if (item.GetEquipmentSlot() == EquipableSlot.ring)
        {
            AddToInventory(_playerEquipment[1]);//Agarro el equipableItem que ya está en mi slot y lo pongo en mi inventario
            _playerEquipment[1] = null;
            return;
        }

        if (item.GetEquipmentSlot() == EquipableSlot.artifact)
        {
            AddToInventory(_playerEquipment[2]);//Agarro el equipableItem que ya está en mi slot y lo pongo en mi inventario
            _playerEquipment[2] = null;
            return;
        }
    }


    public void RemoveFromInventory(BaseItem item)
    {
        _amountOfItemsInBag--;

        for (int i = 0; i < _playerBag.Length; i++)
        {
            if (_playerBag[i] == item)
            {
                _playerBag[i] = null;

                return;
            }
        }
    }

    public BaseItem GetItem(int itemIndex)
    {
        return _playerBag[itemIndex];
    }

    public int GetAmountOfItemsInInventory()
    {
        return _amountOfItemsInBag;
    }
}
