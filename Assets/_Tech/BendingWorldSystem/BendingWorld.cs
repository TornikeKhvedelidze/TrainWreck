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

    private float sidewaysBend = 0f;
    private float backwardBend = 0f;

    private Tween sidewaysTween;
    private Tween backwardTween;

    void Start()
    {
        SetNewTargets();
    }

    void Update()
    {
        foreach (var mat in bendingMaterials)
        {
            mat.SetFloat("_Sideways", sidewaysBend);
            mat.SetFloat("_Backwards", backwardBend);
        }
    }

    void SetNewTargets()
    {
        float newSideways = Random.Range(sidewaysRange.x, sidewaysRange.y);
        float newBackward = Random.Range(backwardRange.x, backwardRange.y);

        sidewaysTween?.Kill();
        backwardTween?.Kill();

        sidewaysTween = DOTween.To(() => sidewaysBend, x => sidewaysBend = x, newSideways, bendSpeed).SetEase(Ease.InOutSine);
        backwardTween = DOTween.To(() => backwardBend, x => backwardBend = x, newBackward, bendSpeed).SetEase(Ease.InOutSine).OnComplete(SetNewTargets);
    }
}
