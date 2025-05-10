using LutorGames.SaveSystem;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency_SO", menuName = "Scriptable Objects/Currency_SO")]
public class Currency_SO : RewardSO
{
    public Float_Saveable ValueSaveable;
    public float valuetest;
    public Sprite Icon;
    public float Value => ValueSaveable.Value;

    public Action<float> OnValueChanged
    {
        get => ValueSaveable.OnValueChanged;
        set => ValueSaveable.OnValueChanged = value;
    }

    public Action OnValueChangedNoArgs
    {
        get => ValueSaveable.OnValueChangedNoArgs;
        set => ValueSaveable.OnValueChangedNoArgs = value;
    }

    public virtual bool AbleToPay(float amount)
    {
        if (Value < amount) return false;

        return true;
    }

    public virtual bool TryPay(float amount)
    {
        if (!AbleToPay(amount)) return false;

        ValueSaveable.Value -= amount;

        return true;
    }
}
