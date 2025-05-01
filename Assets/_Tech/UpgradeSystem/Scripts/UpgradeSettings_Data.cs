using LutorGames.SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PayingOption
{
    public Currency_SO Currency;
    public float Amount;
}

[Serializable]
public class PriceAndValue
{
    public float Value;
    public bool PayWithAd;
    public List<PayingOption> PayingOptions;

    public bool Price(out PayingOption payingOption)
    {
        payingOption = PayingOptions[0];

        foreach (var option in PayingOptions)
        {
            if (!option.Currency.AbleToPay(option.Amount)) continue;

            payingOption = option;

            return true;
        }

        return false;
    }
}

[Serializable]
public class UpgradeSetting
{
    public Int_Saveable Level;
    public List<PriceAndValue> Settings;

    public string Name => Level.Id;
    public bool IsMaxed => Level.Value >= Settings.Count - 1;
    public PriceAndValue Default_Value => Settings[0];
    public PriceAndValue Current_Value => Settings[Level.Value];
    public PriceAndValue Next_Value => Settings[IsMaxed ? Level.Value : Level.Value + 1];

    public bool TryUpgrade(PayingOption payingOption)
    {
        if (IsMaxed) return false;

        if (!payingOption.Currency.TryPay(payingOption.Amount)) return false;

        Upgrade();

        return true;
    }

    public bool Upgrade()
    {
        if (IsMaxed) return false;

        Level.Value += 1;

        return true;
    }
}

[CreateAssetMenu(fileName = "UpgradeSettings_Data", menuName = "Scriptable Objects/UpgradeSettings_Data")]
public class UpgradeSettings_Data : ScriptableObject
{
    public List<UpgradeSetting> UpgradeSettings;
}
