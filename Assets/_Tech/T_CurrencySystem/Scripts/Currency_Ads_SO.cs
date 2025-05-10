using UnityEngine;

[CreateAssetMenu(fileName = "Currency_Ads_SO", menuName = "Scriptable Objects/Currency_Ads_SO")]
public class Currency_Ads_SO : Currency_SO
{
    public override bool AbleToPay(float amount)
    {
        return true;
    }

    public override bool TryPay(float amount)
    {
        //TODO: add ads

        return true;
    }
}
