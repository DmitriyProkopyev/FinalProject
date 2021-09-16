using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private bool _actionAfterPlayIsDone = false;
    private bool _playingHasStarted = false;
    private ActionAfterPlay _action;

    protected AudioSource AudioSource;

    public void Initialize(SoundSettings settings)
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = settings.Sounds[Random.Range(0, settings.Sounds.Length)];
        AudioSource.volume = settings.Volume;
        AudioSource.pitch = settings.Pitch;
    }

    private void Update()
    {
        if (_actionAfterPlayIsDone || AudioSource == null || !_playingHasStarted)
            return;

        if (!AudioSource.isPlaying)
        {
            _actionAfterPlayIsDone = true;
            switch (_action)
            {
                case ActionAfterPlay.Nothing:
                    return;
                case ActionAfterPlay.SelfDestroy:
                    Destroy(gameObject);
                    return;
            }
        }
    }

    public void Play(SoundPlayingType type, ActionAfterPlay action = ActionAfterPlay.Nothing)
    {
        AudioSource.loop = (type == SoundPlayingType.Looped);
        AudioSource.Play();

        _action = action;
        _playingHasStarted = true;
    }

    public void Stop() => AudioSource.Stop();

    public enum SoundPlayingType
    {
        Single,
        Looped
    }

    public enum ActionAfterPlay
    {
        Nothing,
        SelfDestroy
    }
}
