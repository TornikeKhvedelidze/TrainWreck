using UnityEngine;
using UnityEngine.UI;

public class LayoutOptimiser : MonoBehaviour
{
    [SerializeField] private float _disableDuration = 1;
    [SerializeField] private LayoutGroup _layout;
    private float _timer;
    private bool _isActive;

    private void OnEnable()
    {
        _timer = 0;

        SetLayoutActive(true);
    }
    private void OnDisable()
    {
        _timer = _disableDuration;

        SetLayoutActive(false);
    }
    private void Update()
    {
        if (_timer >= _disableDuration)
        {
            if (_isActive) SetLayoutActive(false);
            return;
        }

        _timer += Time.deltaTime;
    }

    private void SetLayoutActive(bool value)
    {
        _layout.enabled = value;
        _isActive = value;
    }
}
