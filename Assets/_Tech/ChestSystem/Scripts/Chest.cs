using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Chest : MonoBehaviour
{
    [SerializeField] private ChestSO _chestSO;
    [SerializeField] private Button_SO _openChestSO;
    private Sequence _chestSequence;
    
    private void Start()
    {
        
    }

    public void Initialization(float riseHeight, float duration, float rotationAngle)
    {
        _openChestSO.OnPressed += OnClicked;
        PlayRiseAndRotate(riseHeight,duration,rotationAngle);   
    }

    public void PlayRiseAndRotate(float riseHeight, float duration, float rotationAngle)
    {
        _chestSequence = DOTween.Sequence();
        
        _chestSequence.Join(transform.DOMoveY(transform.position.y + riseHeight, duration).SetEase(Ease.OutBack));
        _chestSequence.Join(transform.DORotate(new Vector3(0, rotationAngle, 0), duration, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
    }

    public void OnClicked()
    {
        _chestSequence.timeScale = 5f;
    }

    public void OpenChest()
    {
        List<WeightedElement<RewardSO>> rewards = _chestSO.ChestRewardInfo.elements;

        int amountToOpen = _chestSO.Amount.Value;
        Debug.Log(amountToOpen);

        for (int i = 0; i < amountToOpen; i++)
        {
            RewardSO rewardData = Attributes.GetRandomElement(rewards);
            GiveReward(rewardData);
        }
    }

    private void GiveReward(RewardSO rewardSO)
    {
        rewardSO.ApplyReward();
    }
}
