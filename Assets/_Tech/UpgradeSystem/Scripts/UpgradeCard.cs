using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text UpgradeText;
    [SerializeField] private TMP_Text PriceText;

    private UpgradeSetting _upgradeSetting;

    private void Start()
    {
        _upgradeButton.onClick.AddListener(() => TryUpgrade());
    }

    public void Initialise(UpgradeSetting setting)
    {
        _upgradeSetting = setting;

        UpdateSettings();
    }

    public bool TryUpgrade()
    {
        if (!_upgradeSetting.TryUpgrade())
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
        UpgradeText.text = $"+{_upgradeSetting.Next_Value.Value - _upgradeSetting.Current_Value.Value}";
        PriceText.text = $"{_upgradeSetting.Current_Value.Price}$";
    }

    private void NotEnoughMoneyMessage()
    {
        Debug.LogWarning("Not Enough Money");
        //TODO: add warning visual
    }
}
