using UnityEngine;

public class SceneController : Singleton<SceneController>
{
    [SerializeField] private Bool_SO _isPlaying;

    protected override void Awake()
    {
        base.Awake();

        _isPlaying.Value = false;
    }
}
