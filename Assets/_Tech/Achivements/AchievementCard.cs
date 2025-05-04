using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Image _background;

    public void Initialization(AchievementInfo info)
    {
        _nameText.text = info.Name;
        _descriptionText.text = info.description;

        _background.color = info.IsClaimed ? Color.yellow : info.IsCompleted ? Color.green : Color.white;
    }
}
