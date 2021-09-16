using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class BorderWarning : MonoBehaviour
{
    [SerializeField] private Border _border;
    [SerializeField] private readonly SoundSettings _settings;

    private SoundPlayer _soundPlayer;

    private void OnEnable()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        _soundPlayer.Initialize(_settings);
        _border.Crossed += OnBorderCrossed;
    }

    private void OnDisable() => _border.Crossed -= OnBorderCrossed;

    private void OnBorderCrossed() => _soundPlayer.Play(SoundPlayer.SoundPlayingType.Single);
}
