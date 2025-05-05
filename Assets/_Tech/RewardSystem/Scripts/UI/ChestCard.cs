using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChestCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _chestRarityText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _chestAmountText;
    [SerializeField] private Image _background; //will be colored based on chest rarity
    [SerializeField] private Image _icon;
    
    private ChestSO _chestSO;
    private int _amount;

    private void Start()
    {
       
    }

    public void Initialization(ChestSO info, int amount)
    {
        _chestSO = info;
        _amount = amount;
        
        UpdateCard();
    }

    void UpdateCard()
    {
        _chestRarityText.text = _chestSO.ChestRarity.ToString();
        _descriptionText.text = _chestSO.Description;
        _chestAmountText.text = _amount + "X";
        
        if(_icon == null) return;
        _icon.sprite = _chestSO.Icon;
    }
}
