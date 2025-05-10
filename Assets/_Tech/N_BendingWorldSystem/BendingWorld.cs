using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class BendingController : Singleton<BendingController>
{
    [SerializeField] private List<Material> bendingMaterials;

    [Header("Bend Range")]
    [SerializeField] private Vector2 sidewaysRange = new(-1f, 1f);
    [SerializeField] private Vector2 backwardRange = new(-1f, 1f);

    [Header("Bend Speed")]
    [SerializeField] private float bendSpeed = 1f;

    [SerializeField] private Bool_SO IsPlaying_SO;

    private float sidewaysBend = 0f;
    private float backwardBend = 0f;

    private Tween sidewaysTween;
    private Tween backwardTween;

    private bool _isBending = true;

    protected override void Awake()
    {
        base.Awake();

        if (IsPlaying_SO.Value) SetNewTargets();

        IsPlaying_SO.OnChanged += SetObstaclesActive;
    }

    void Update()
    {
        foreach (var mat in bendingMaterials)
        {
            mat.SetFloat("_Sideways", sidewaysBend);
            mat.SetFloat("_Backwards", backwardBend);
        }
    }

    private void SetObstaclesActive(bool value)
    {
        _isBending = value;
    }

    private void SetNewTargets()
    {
        float newSideways = _isBending ? Random.Range(sidewaysRange.x, sidewaysRange.y) : 0;
        float newBackward = _isBending ? Random.Range(backwardRange.x, backwardRange.y) : 0;

        sidewaysTween?.Kill();
        backwardTween?.Kill();

        sidewaysTween = DOTween.To(() => sidewaysBend, x => sidewaysBend = x, newSideways, bendSpeed).SetEase(Ease.InOutSine);
        backwardTween = DOTween.To(() => backwardBend, x => backwardBend = x, newBackward, bendSpeed).SetEase(Ease.InOutSine).OnComplete(SetNewTargets);
    }
}
