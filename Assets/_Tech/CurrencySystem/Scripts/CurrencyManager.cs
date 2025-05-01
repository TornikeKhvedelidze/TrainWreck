using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{
    [SerializeField] List<Currency_SO> _currencies;

    public static Action OnAnyValuesChanged;

    protected override void Awake()
    {
        base.Awake();

        SubscribeToAllCurrencies();
    }

    private void SubscribeToAllCurrencies()
    {
        _currencies.ForEach(x => x.OnValueChanged += OneOfCurrenciesChanged);
    }

    private void OneOfCurrenciesChanged(float value)
    {
        OnAnyValuesChanged?.Invoke();
    }


}
