using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    private Image _abImage = null;
    private Text _abText = null;

    private void Awake()
    {
        _abText = GetComponentInChildren<Text>();
    }

    public Image GetImage() { return _abImage; }
    public Text GetText() { return _abText; }

    public void SetImage(Image _image) { _abImage = _image; }
    public void SetText(string _text) { _abText.text = _text; }


    public void Remove()
    {
        AbilityHUD.GetInstance().RemoveAbilityFromEquipped(this);
    }
}
