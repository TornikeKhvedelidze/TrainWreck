using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _chestRarityText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _chestAmountText;
    [SerializeField] private Image _background; //will be colored based on chest rarity
    [SerializeField] private Image _icon;
    [SerializeField] private Button _openButton;
    [HideInInspector] public bool IsActive { get; set; }

    private ChestSO _chestSO;

    public void Initialization(ChestSO info)
    {
        _chestSO = info;

        info.Amount.OnValueChangedNoArgs -= UpdateCard;
        info.Amount.OnValueChangedNoArgs += UpdateCard;

        _openButton.onClick.RemoveAllListeners();
        _openButton.onClick.AddListener(OpenChest);

        UpdateCard();
    }

    private void UpdateCard()
    {
        _chestRarityText.text = _chestSO.Name;
        _descriptionText.text = _chestSO.Description;
        _chestAmountText.text = _chestSO.Amount.Value + "X";

        if (_icon == null) return;
        _icon.sprite = _chestSO.Icon;
    }

    private void OpenChest()
    {
        ChestManager.OpenChest(_chestSO);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        IsActive = active;
    }

}
