using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptable", menuName = "CreateScriptable/Button")]
public class Button_SO : ScriptableObject
{
    public Action OnPressed;

    public void Invoke()
    {
        OnPressed?.Invoke();
    }
}
