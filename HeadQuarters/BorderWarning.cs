using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class BorderWarning : MonoBehaviour
{
    [SerializeField] private Border _border;
    [SerializeField] private SoundSettings _settings;

    private SoundPlayer _player;

    private void OnEnable()
    {
        _player = GetComponent<SoundPlayer>();
        _player.Initialize(_settings);
        _border.Crossed += OnBorderCrossed;
    }

    private void OnDisable()
    {
        _border.Crossed -= OnBorderCrossed;
    }

    private void OnBorderCrossed()
    {
        _player.Play(SoundPlayer.SoundPlayingType.Single);
    }
}
