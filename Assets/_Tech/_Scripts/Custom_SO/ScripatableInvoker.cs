using CustomInspector;
using UnityEngine;

public class ScripatableInvoker : MonoBehaviour
{
    [SerializeField] private bool _Empty;
    [SerializeField, HideIf("_Empty", false)] private Button_SO _ButtonScriptable;
    [SerializeField] private bool _int;
    [SerializeField, HideIf("_int", false)] private int _defaultIntValue;
    [SerializeField, HideIf("_int", false)] private Int_SO _intButtonScriptable;
    [SerializeField] private bool _float;
    [SerializeField, HideIf("_float", false)] private float _defaultFloatValue;
    [SerializeField, HideIf("_float", false)] private Float_SO _floatButtonScriptable;
    [SerializeField] private bool _bool;
    [SerializeField, HideIf("_bool", false)] private bool _defaultBoolValue;
    [SerializeField, HideIf("_bool", false)] private Bool_SO _boolButtonScriptable;


    public void Press()
    {
        if (_Empty) _ButtonScriptable.Invoke();
        if (_int) _intButtonScriptable.Value = _defaultIntValue;
        if (_float) _floatButtonScriptable.Value = _defaultFloatValue;
        if (_bool) _boolButtonScriptable.Value = _defaultBoolValue;
    }
    public void CustomPress()
    {
        if (!_Empty)
        {
            LogError();
            return;
        }

        _ButtonScriptable.Invoke();
    }
    public void CustomPress(int value)
    {
        if (!_int)
        {
            LogError();
            return;
        }

        _intButtonScriptable.Value = value;
    }
    public void CustomPress(float value)
    {
        if (!_float)
        {
            LogError();
            return;
        }

        _floatButtonScriptable.Value = value;
    }
    public void CustomPress(bool value)
    {
        if (!_bool)
        {
            LogError();
            return;
        }

        _boolButtonScriptable.Value = value;
    }

    private void LogError()
    {
        Debug.LogError($"YOU CALLED THE WRONG SCRIPTABLE IN {name}", this);
    }

}
