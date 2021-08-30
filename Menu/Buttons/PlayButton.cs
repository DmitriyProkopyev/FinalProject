using UnityEngine;

public class PlayButton : MenuButton
{
    [SerializeField] private string _sceneName;

    protected override void OnClick()
    {
        LevelLoader.Load(_sceneName);
    }
}
