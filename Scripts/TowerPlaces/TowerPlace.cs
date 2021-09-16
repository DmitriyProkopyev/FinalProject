using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class TowerPlace : MonoBehaviour
{
    [SerializeField] private Transform _towerPoint;
    [SerializeField] private TowerPlacingEffect _effect;
    [SerializeField] private SoundSettings _settings;

    public bool IsFree { get; private set; } = true;

    private SoundPlayer _soundPlayer;
    private readonly Tower _tower;

    private void OnEnable()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        _soundPlayer.Initialize(_settings);
    }

    public bool TryTakePosition(out Vector3 position)
    {
        position = Vector3.zero;

        if (IsFree)
        {
            position = _towerPoint.position;
            _effect.Play();
            _soundPlayer.Play(SoundPlayer.SoundPlayingType.Single);
            IsFree = false;
            return true;
        }

        return false;
    }

    public void LeavePosition() => IsFree = true;
}
