using UnityEngine.UI;

public class PurchasableAbilitySlot : ShopAbilitySlot
{
    private void Awake()
    {
        _abText = GetComponentInChildren<Text>();
    }

    public void BuyAbilityFromListUI()
    {
        AbilityHUD.GetInstance().AddToAvailableAbilityList(this);
    }
}
