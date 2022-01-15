using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHUD : MonoBehaviour
{
    private static AbilityHUD _instance = null;

    [SerializeField] private AbilitySlot[] _activeAbilitiesHUD;
    [SerializeField] private AbilitySlot[] _passiveAbilitiesHUD;
    private List<PurchasableAbilitySlot> _purchasableAbilitiesHUD;
    private List<AvailableAbilitySlot> _availableAbilitiesHUD;
    [SerializeField] private PurchasableAbilitySlot _purchasableAbilitySlotPrefab;
    [SerializeField] private Transform _purchaseLayout;
    [SerializeField] private AvailableAbilitySlot _availableAbilitySlotPrefab;
    [SerializeField] private Transform _availableLayout;
    [SerializeField] private Transform _activeAbGrid;
    [SerializeField] private Transform _passiveAbGrid;
    [SerializeField] private GameObject _abilitiesEquippedUI;
    [SerializeField] private GameObject _abilitiesShopUI;

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

    public static AbilityHUD GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        InitializeHUD();
        PlayerSingleton.GetInstance().GetPlayer().OpenCloseInventory += OpenCloseAbilitySlots;
        PlayerSingleton.GetInstance().GetPlayer().OpenCloseAbilities += OpenCloseAbilityMenu;
    }


    public void InitializeHUD()
    {
        _activeAbilitiesHUD = _activeAbGrid.GetComponentsInChildren<AbilitySlot>();
        _passiveAbilitiesHUD = _passiveAbGrid.GetComponentsInChildren<AbilitySlot>();

        _purchasableAbilitiesHUD = new List<PurchasableAbilitySlot>();
        _availableAbilitiesHUD = new List<AvailableAbilitySlot>();

        DynamicallyInstanceAbilitiesInHUD();
    }

    private void DynamicallyInstanceAbilitiesInHUD()
    {
        List<AbilityNode> purchasableAbilities = PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPurchasableAbilitiesList();
        List<AbilityNode> availableAbilities = PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetAvailableAbilitiesList();

        for (int i = 0; i < purchasableAbilities.Count; i++)
        {
            PurchasableAbilitySlot newPurchsableAbility = Instantiate(_purchasableAbilitySlotPrefab, _purchaseLayout);
            _purchasableAbilitiesHUD.Add(newPurchsableAbility);
            //purchasableAbilitiesHUD[i].SetImage(purchasableAbilities[i].GetImage());
            _purchasableAbilitiesHUD[i].SetID(purchasableAbilities[i].GetAbilityID());
            _purchasableAbilitiesHUD[i].SetText(purchasableAbilities[i].GetAbilityName());
        }

        for (int i = 0; i < availableAbilities.Count; i++)
        {
            AvailableAbilitySlot newAvailableAbility = Instantiate(_availableAbilitySlotPrefab, _availableLayout);
            _availableAbilitiesHUD.Add(newAvailableAbility);
            //purchasableAbilitiesHUD[i].SetImage(purchasableAbilities[i].GetImage());
            _availableAbilitiesHUD[i].SetID(purchasableAbilities[i].GetAbilityID());
            _availableAbilitiesHUD[i].SetText(purchasableAbilities[i].GetAbilityName());
        }
    }

    public void OpenCloseAbilitySlots()//método que cargo en la acción del PlayerActor--> Input I
    {
        _abilitiesEquippedUI.SetActive(!_abilitiesEquippedUI.activeSelf);

        UpdateEquippedUI();
    }
    public void OpenCloseAbilityMenu()//método que cargo en la acción del PlayerActor--> Input K
    {
        _abilitiesShopUI.SetActive(!_abilitiesShopUI.activeSelf);

        UpdateShopUI();
    }

    public void UpdateShopUI()
    {
        bool abilityWasFound;
        //playerRef.GetCharacter().GetAvailableAbilitiesList();

        for (int i = 0; i < PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPurchasableAbilitiesList().Count; i++)
        {
            abilityWasFound = false;//Seteo esto como falso acá para que no agregué cada habilidad

            foreach (PurchasableAbilitySlot ability in _purchasableAbilitiesHUD)
            {
                if (ability.GetID() == PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPurchasableAbilitiesList()[i].GetAbilityID())
                {
                    abilityWasFound = true;
                }
            }

            if (!abilityWasFound)
            {
                _purchasableAbilitiesHUD.Add(Instantiate(_purchasableAbilitySlotPrefab, _purchaseLayout));
                _purchasableAbilitiesHUD[i].SetID(PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPurchasableAbilitiesList()[i].GetAbilityID());
                //purchasableAbilitiesHUD[i].SetImage(purchasableAbilities[i].GetImage());
                _purchasableAbilitiesHUD[i].SetText(PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPurchasableAbilitiesList()[i].GetAbilityName());
            }
            else
            {
                _purchasableAbilitiesHUD[i].gameObject.SetActive(_abilitiesShopUI.activeSelf);
            }
        }
    }

    public void UpdateEquippedUI()
    {
        //Hago dos for porque tengo dos arrays distintos---> una porquería (arreglar)
        for (int i = 0; i < _activeAbilitiesHUD.Length; i++)
        {
            if (PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetActiveAbilities()[i] != null)
            {
                _activeAbilitiesHUD[i].gameObject.SetActive(true);
                _activeAbilitiesHUD[i].SetText(PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetActiveAbilities()[i].GetAbilityName());
            }
        }

        for (int i = 0; i < _passiveAbilitiesHUD.Length; i++)
        {
            if (PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPassiveAbilities()[i] != null)
            {
                _passiveAbilitiesHUD[i].gameObject.SetActive(true);
                _passiveAbilitiesHUD[i].SetText(PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPassiveAbilities()[i].GetAbilityName());
            }
        }
    }

    public void RemoveAbilityFromEquipped(AbilitySlot abilitySlot)
    {
        //Hago dos for porque tengo dos arrays distintos---> una porquería (arreglar)
        for (int i = 0; i < _activeAbilitiesHUD.Length; i++)
        {
            if (_activeAbilitiesHUD[i] == abilitySlot)
            {
                PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetActiveAbilities()[i] = null;

                abilitySlot.gameObject.SetActive(false);

                return;
            }
        }

        for (int i = 0; i < _passiveAbilitiesHUD.Length; i++)
        {
            if (_passiveAbilitiesHUD[i] == abilitySlot)
            {
                PlayerSingleton.GetInstance().GetPlayer().GetCharacter().GetPassiveAbilities()[i] = null;

                abilitySlot.gameObject.SetActive(false);

                return;
            }
        }
    }

    public void AddToAvailableAbilityList(PurchasableAbilitySlot _purchasedAbility)
    {
        if (!PlayerSingleton.GetInstance().GetPlayer().GetCharacter().BuyAbility(_purchasedAbility.GetID()))//No puedo comprar la habilidad
        {
            Debug.Log("No se pudo comprar la habilidad--Quizás no tenga puntos suficientes");
        }
        else
        {
            foreach (PurchasableAbilitySlot abilityToMove in _purchasableAbilitiesHUD)
            {
                if (_purchasedAbility.GetID() == abilityToMove.GetID())
                {
                    AvailableAbilitySlot newAvailableAbility = Instantiate(_availableAbilitySlotPrefab, _availableLayout);

                    _availableAbilitiesHUD.Add(newAvailableAbility);

                    for (int i = 0; i < _availableAbilitiesHUD.Count; i++)
                    {
                        if (_availableAbilitiesHUD[i] == newAvailableAbility)
                        {
                            _availableAbilitiesHUD[i].SetID(_purchasedAbility.GetID());
                            //newAvailableAbility.SetImage(_purchasedAbility.GetImage());
                            _availableAbilitiesHUD[i].SetText(_purchasedAbility.GetTextString());
                        }
                    }
                }
            }
            _purchasableAbilitiesHUD.Remove(_purchasedAbility);

            UpdateShopUI();
        }
    }

    public void AddAbilityToPlayerArray(AvailableAbilitySlot _availableAbility)
    {
        if (!PlayerSingleton.GetInstance().GetPlayer().GetCharacter().AddAbilityFromAvailableList(_availableAbility.GetID()))
        {
            Debug.Log("Esta habilidad no pudo ser agregada. Quizás ya forme parte de sus arrays.");
        }
        else
        {
            //Por ahora, nada.
        }
    }


}

//Este código instancia AbilitySlots de manera dinámica, pero me rompía todo. Lo dejo acá porque ta bueno que se yo.

//for (int i = 0; i < activeAbilitiesHUD.Length; i++)
//{
//    if (playerRef.GetCharacter().GetActiveAbilities()[i] != null)
//    {
//        activeAbilitiesHUD[i] = Instantiate(abilitySlotPrefab, activeAbGrid);
//        //abilities[i].SetImage(playerRef.GetCharacter().GetActiveAbilities()[i].Getimage())

//        activeAbilitiesHUD[i].SetText(playerRef.GetCharacter().GetActiveAbilities()[i].GetAbilityName());
//    }
//}

//for (int i = 0; i < passiveAbilitiesHUD.Length; i++)
//{
//    if (playerRef.GetCharacter().GetPassiveAbilities()[i] != null)
//    {
//        passiveAbilitiesHUD[i] = Instantiate(abilitySlotPrefab, passiveAbGrid);
//        //abilities[i].SetImage(playerRef.GetCharacter().GetPassiveAbilities()[i].Getimage())

//        passiveAbilitiesHUD[i].SetText(playerRef.GetCharacter().GetPassiveAbilities()[i].GetAbilityName());
//    }
//}
