using UnityEngine.UI;

public class AvailableAbilitySlot : ShopAbilitySlot
{
    private void Awake()
    {
        _abText = GetComponentInChildren<Text>();
    }

    public void AddAbilityToArrayFromListUI()
    {
        AbilityHUD.GetInstance().AddAbilityToPlayerArray(this);
    }


}
