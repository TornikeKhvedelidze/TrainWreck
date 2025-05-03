using UnityEngine;

public class AchievementPanel : MonoBehaviour
{
    [SerializeField] private AchievementCard _card;
    [SerializeField] private Transform _cardParent;
    public void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        var Achievements = AchievementManager.GetAllAchievements();

        foreach (var achievement in Achievements)
        {
            var card = Instantiate(_card, _cardParent);
            card.Initialization(achievement);
        }
    }
}
