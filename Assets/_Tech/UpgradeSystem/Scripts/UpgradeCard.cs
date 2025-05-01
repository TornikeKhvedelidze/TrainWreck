using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text UpgradeText;
    [SerializeField] private TMP_Text PriceText;
    [SerializeField] private Image PriceIcon;

    private UpgradeSetting _upgradeSetting;
    private PayingOption _payingOption;
    private PriceAndValue _currentPriceAndValue => _upgradeSetting.Current_Value;

    private void Start()
    {
        _upgradeButton.onClick.AddListener(() => TryUpgrade());

        CurrencyManager.OnAnyValuesChanged += UpdateSettings;
    }

    public void Initialise(UpgradeSetting setting)
    {
        _upgradeSetting = setting;

        UpdateSettings();
    }

    public bool TryUpgrade()
    {
        if (!_upgradeSetting.TryUpgrade(_payingOption))
        {
            NotEnoughMoneyMessage();
            return false;
        }

        UpdateSettings();

        return true;
    }

    private void UpdateSettings()
    {
        if (_upgradeSetting == null) return;

        NameText.text = _upgradeSetting.Name;
        UpgradeText.text = $"+{_upgradeSetting.Next_Value.Value - _currentPriceAndValue.Value}";

        _currentPriceAndValue.Price(out _payingOption);

        PriceText.text = _payingOption.Amount.ToString();
        PriceIcon.sprite = _payingOption.Currency.Icon;
    }

    private void NotEnoughMoneyMessage()
    {
        Debug.LogWarning("Not Enough Money");
        //TODO: add warning visual
    }
}
