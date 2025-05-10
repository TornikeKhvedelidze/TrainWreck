using TMPro;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TMP_Text _chestName, _chestDescription;

    [Header("Chest Intro Animation")]
    [SerializeField]
    private Transform spawnPosition;

    [SerializeField] private float riseHeight = 2f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float rotationAngle = 360f;

    [SerializeField] private GameObject _elements;
    [SerializeField] ChestInvoker_ESO _chestInvoker_ESO;
    [SerializeField] private Button_SO _openCurrentChest_ESO;
    private Chest _chestScript;
    private GameObject _spawnedChest;


    private void Awake()
    {
        SetActive(false);
        _chestInvoker_ESO.OnChanged += SetupChest;
        _openCurrentChest_ESO.OnPressed += OpenChest;
    }

    private void OnDisable()
    {
        RemoveChest();
    }

    public void Initialization(ChestSO chestInfo)
    {
        _chestName.text = chestInfo.Name;
        _chestDescription.text = chestInfo.Description;
    }

    private void SetupChest(ChestSO chestSO)
    {
        SetActive(true);
        Initialization(chestSO);
        _chestScript = Instantiate(chestSO.chestPrefab, spawnPosition);
        _chestScript.Initialization(riseHeight, duration, rotationAngle);
    }

    private void RemoveChest()
    {
        Destroy(_spawnedChest);
    }

    private void SetActive(bool active)
    {
        _elements.SetActive(active);
    }

    private void OpenChest()
    {
        _chestScript.OpenChest();
    }
}
