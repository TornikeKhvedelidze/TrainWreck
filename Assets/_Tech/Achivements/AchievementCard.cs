using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _claim;
    [SerializeField] private Button _complete;
    [SerializeField] private Image _backGround;
    public void Initialization(AchievementInfo info)
    {
        _name.text = info.name;
        _description.text = info.description;
        _claim.onClick.RemoveAllListeners();
        _claim.onClick.AddListener(() => info.status.isClamed = true);
        _complete.onClick.RemoveAllListeners();
        _complete.onClick.AddListener(() => info.status.isComplete = true);
        _backGround.color = info.isClaimed? Color.yellow: info.isCompleted ? Color.green: Color.white;
    }
}
