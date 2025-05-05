using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] private ChestCard _chestCard;
    [SerializeField] private Transform _cardsParent;

    public void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        // //Dictionary<ChestSO,int> chestsDictionary = ChestManager.GetAllChests();
        //
        // foreach (var chestSO in chestsDictionary.Keys)
        // {
        //     var chestCard = Instantiate(_chestCard, _cardsParent);
        //     chestCard.Initialization(chestSO,chestsDictionary[chestSO]);
        // }
    }
}
