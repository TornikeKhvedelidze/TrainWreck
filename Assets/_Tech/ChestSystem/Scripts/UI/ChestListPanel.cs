using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestListPanel : MonoBehaviour
{
    [SerializeField] private ChestCard _chestCard;
    [SerializeField] private Transform _cardsParent;
    private List<ChestCard> _chestCards = new List<ChestCard>();

    public void OnEnable()
    {
        Initialization();
    }

    private void OnDisable()
    {
        _chestCards.ForEach(x => x.SetActive(false));
    }

    public void Initialization()
    {
        var chests = ChestManager.GetAllAvailableChests();

        foreach (var chestSO in chests)
        {
            var chestCard = GetChestCard();
            chestCard.Initialization(chestSO);
        }
    }

    private ChestCard GetChestCard()
    {
        ChestCard chestCard = _chestCards.FirstOrDefault(x => !x.IsActive);
        if (chestCard == null)
        {
            chestCard = Instantiate(_chestCard, _cardsParent);
            _chestCards.Add(chestCard);
        }
        chestCard.SetActive(true);

        return chestCard;
    }
}
