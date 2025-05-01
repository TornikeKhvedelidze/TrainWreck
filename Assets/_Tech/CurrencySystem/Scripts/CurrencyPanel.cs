using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyPanel : MonoBehaviour
{
    [SerializeField] private Image _currencyIcon;
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private Currency_SO _currency;


    void Start()
    {
        Initialise();

        _currency.OnValueChanged += UpdatePanel;
    }

    private void Initialise()
    {
        _currencyIcon.sprite = _currency.Icon;

        UpdatePanel(_currency.Value);
    }

    private void UpdatePanel(float value)
    {
        _currencyText.text = value.ToString();
    }
}
