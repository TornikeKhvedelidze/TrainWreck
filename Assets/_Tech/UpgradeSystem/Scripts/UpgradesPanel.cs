using UnityEngine;

public class UpgradesPanel : MonoBehaviour
{
    [SerializeField] private UpgradeSettings_Data _data;
    [SerializeField] private UpgradeCard _upgradeCard;
    [SerializeField] private Transform _cardsParent;

    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        _data.UpgradeSettings.ForEach(x => SpawnCard(x));
    }

    private void SpawnCard(UpgradeSetting setting)
    {
        var card = Instantiate(_upgradeCard, _cardsParent);

        card.Initialise(setting);
    }
}
