using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class PlayerActor : MonoBehaviour
{
    [SerializeField] private PlayableCharacter _character = null;

    private float _horizontalMovement = 0f;
    private float _jumpVelocity = 8f;
    private bool _bJump = false;

    private Camera _cam;

    public event Action OpenCloseInventory;
    public event Action OpenCloseAbilities;
    public event Action OpenCloseQuests;

    private const float DEFAULT_TEMPORARY_VALUE = 10.0f;
    private float _temporaryItemTimer = DEFAULT_TEMPORARY_VALUE;
    private bool _isTemporaryItemActive = false;
    private BaseCharacter.Stats _temporaryItemStats;

    private void Awake()
    {
        PlayerSingleton.GetInstance().SetPlayer(this);

        SetCharacter();

        _cam = Camera.main;

        SetDialogueSystem();

        Debug.Log(_character.GetStats());
    }

    public void GetInput()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _bJump = Input.GetButtonDown("Jump");

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("La clase es " + _character);
        }

        if (Input.GetMouseButtonDown(1))//Righ click para interactuar con las cosas
        {
            Interact();
        }

        //Abro el inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseInventory?.Invoke();
        }

        //Abro el menu de habilidades para comprar y equipar
        if (Input.GetKeyDown(KeyCode.K))
        {
            OpenCloseAbilities?.Invoke();
        }

        //Abro el menu para ver las habilidades
        if (Input.GetKeyDown(KeyCode.J))
        {
            OpenCloseQuests?.Invoke();
        }

    }

    private void Jump()
    {
        if (_bJump)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * _jumpVelocity;
        }
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(_horizontalMovement, 0f, 0f);
        transform.position += movement * Time.deltaTime * _character.GetSpeed();
    }

    internal void SetTemporaryItemVariables(bool _setTemporaryActive, BaseCharacter.Stats _temporaryItemStats)
    {
        _isTemporaryItemActive = _setTemporaryActive;
        this._temporaryItemStats = _temporaryItemStats;
    }

    public void Interact()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))//Un cierto rango para interactuar con las cosas
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();//es interactuable lo que acabo de clickear?

            if (interactable != null)
            {
                if (interactable.IsItem())
                {
                    bool wasItemPickedUp = _character.GetInventory().AddToInventory(interactable.GetItem());

                    if (wasItemPickedUp)
                        interactable.Interact();//Hago esto para no desactivar el game object, si no no podría agarrarlo de nuevo
                }
                else
                {
                    interactable.Interact();
                }
            }
        }

    }
    /// <summary>
    /// Set character lee la data del Json y luego setea los stats y el inventario en este character
    /// </summary>
    public void SetCharacter()
    {
        string json = File.ReadAllText(Application.dataPath + "/characterFile.json");

        CharacterData characterData = JsonUtility.FromJson<CharacterData>(json);

        if (characterData.GetDataCharacterClass() == "Rogue")
        {
            _character = new Rogue();
            _character.SetNewStats(characterData.GetDataStats());
            _character.SetInventory(characterData.GetDataInventory());
        }

        if (characterData.GetDataCharacterClass() == "Sorcerer")
        {
            _character = new Sorcerer();
            _character.SetNewStats(characterData.GetDataStats());
            _character.SetInventory(characterData.GetDataInventory());
        }

        if (characterData.GetDataCharacterClass() == "Warrior")
        {
            _character = new Warrior();
            _character.SetNewStats(characterData.GetDataStats());
            _character.SetInventory(characterData.GetDataInventory());
        }
    }

    private void SetDialogueSystem()
    {
        _character.CreateDialogueSystem();
    }

    public PlayableCharacter GetCharacter()
    {
        return _character;
    }

    /// <summary>
    /// Se fija si el item temporal acabo su efecto
    /// </summary>
    private void CheckTemporaryItem()
    {
        _temporaryItemTimer -= Time.deltaTime;

        Debug.Log(_temporaryItemTimer);

        if (_temporaryItemTimer <= 0)
        {
            _isTemporaryItemActive = false;
            _temporaryItemTimer = DEFAULT_TEMPORARY_VALUE;
            _character.SetLessStats(_temporaryItemStats);
        }
    }

    private void Update()
    {
        if (_isTemporaryItemActive)
        {
            CheckTemporaryItem();
        }

        GetInput();
        MovePlayer();
        Jump();
    }

}
