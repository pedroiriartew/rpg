using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopAbilitySlot : MonoBehaviour
{
    protected Image abImage = null;
    [SerializeField] protected Text _abText = null;

    protected int id = 0;

    private void Awake()
    {
        _abText = GetComponentInChildren<Text>();
    }

    public int GetID() { return id; }
    public Image GetImage() { return abImage; }
    public Text GetText() { return _abText; }
    public string GetTextString() { return _abText.text; }
    public void SetID(int _id) { id = _id; }
    public void SetImage(Image _image) { abImage = _image; }
    public void SetText(string _text)
    {
        if (_abText == null)
        {
            _abText = GetComponentInChildren<Text>();
        }

        _abText.text = _text;
    }
}
