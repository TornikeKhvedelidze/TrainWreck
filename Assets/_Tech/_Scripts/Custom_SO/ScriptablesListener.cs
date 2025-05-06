using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptablesListener : MonoBehaviour
{
    [SerializeField] private Bool_SO _boolSO;
    [SerializeField] private UnityEvent OnChanged;
    [SerializeField] private UnityEvent OffChanged;
    [SerializeField] private List<GameObject> _onGameobject;
    [SerializeField] private List<GameObject> _offGameobject;

    private void Start()
    {
        _boolSO.OnChanged += Changed;
    }

    private void OnDestroy()
    {
        _boolSO.OnChanged -= Changed;
    }

    private void Changed(bool value)
    {
        _onGameobject.ForEach(x => x.SetActive(value));
        _offGameobject.ForEach(x => x.SetActive(!value));

        if (value)
        {
            OnChanged.Invoke();
            return;
        }

        OffChanged.Invoke();
    }

}
