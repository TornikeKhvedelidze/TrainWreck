using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Image _achievementIcon;
    [SerializeField] private Image _achievementBackground;
    [SerializeField] private Image _rewardIcon;
    [SerializeField] private Text _rewardText;
    [SerializeField] private Slider _achievementProgress;
    [SerializeField] private TMP_Text _progressionText;
    private AchievementInfo _achievementInfo;
    public void Initialization(AchievementInfo info)
    {
        _achievementInfo = info;
        UpdateCard();
        AchievementManager.OnSomethingChanged += UpdateCard;
    }

    public void Claim()
    {
        if (!_achievementInfo.IsCompleted || _achievementInfo.IsClaimed)
        {
            return;
        }

        AchievementManager.OnSomethingChanged?.Invoke();
        Debug.Log("Get Reward!!!!!");
        _achievementInfo.Status.IsClamed = true;
    }

    public void UpdateCard()
    {
        _nameText.text = _achievementInfo.Name;
        _descriptionText.text = _achievementInfo.Description;
        //_achievementIcon.sprite = _achievementInfo.Icon;
        //_achievementBackground.color = _achievementInfo.Color;
        _progressionText.text = _achievementInfo.IsClaimed ? "Claimed" : _achievementInfo.IsCompleted ? "is Completed" : "In Progress";
    }


    public void TestComplete()
    {
        _achievementInfo.Status.IsComplete = true;
        AchievementManager.OnSomethingChanged?.Invoke();
    }
}
