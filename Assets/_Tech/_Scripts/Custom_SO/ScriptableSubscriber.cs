using UnityEngine;

public class ScriptableSubscriber : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private Button_SO _button;
    [SerializeField] private Bool_SO _endSceneButton;

    private void Start()
    {
        _button.OnPressed += Enable;
    }

    private void OnDestroy()
    {
        _button.OnPressed -= Enable;
    }

    private void Enable()
    {
        _endSceneButton.Value = true;
        //AudioManager.PlayAudio(_audio);
    }
}
