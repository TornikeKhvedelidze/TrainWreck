using TMPro;
using UnityEngine;

public class AchievementCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;

    public void Initialization(AchievementInfo info)
    {
        _nameText.text = info.Name;
        _descriptionText.text = info.description;
    }
}
