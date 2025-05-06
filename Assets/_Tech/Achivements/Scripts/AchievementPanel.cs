using UnityEngine;

public class AchievementPanel : MonoBehaviour
{
    [SerializeField] private AchievementCard _achievementCard;
    [SerializeField] private Transform _cardsParent;

    public void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        var achievements = AchievementManager.GetAllAchievements();

        Debug.Log(achievements.Count);
        foreach (var achievement in achievements)
        {
            var card = Instantiate(_achievementCard, _cardsParent);

            card.Initialization(achievement);
        }
    }
}
