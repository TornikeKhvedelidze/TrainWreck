using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Slider _achievementProgress;
    [SerializeField] private TMP_Text _progressionText;
    [SerializeField] private Button _claimButton;
    private AchievementInfo _achievementInfo;
    public void Initialization(AchievementInfo info)
    {
        _achievementInfo = info;
        UpdateCard();
        AchievementManager.OnSomethingChanged += UpdateCard;
        _claimButton.onClick.AddListener(Claim);
    }

    public void Claim()
    {
        _achievementInfo.Claim();
    }

    public void UpdateCard()
    {
        _nameText.text = _achievementInfo.Name;
        _descriptionText.text = _achievementInfo.Description;
        //_achievementIcon.sprite = _achievementInfo.Icon;
        //_achievementBackground.color = _achievementInfo.Color;
        _progressionText.text = _achievementInfo.IsClaimed ? "Claimed" : _achievementInfo.IsCompleted ? "is Completed" : "In Progress";
        _achievementProgress.value = _achievementInfo.progressRatio;
        _progressionText.text = $"{_achievementInfo.progress} / {_achievementInfo.goal}";
    }
}
