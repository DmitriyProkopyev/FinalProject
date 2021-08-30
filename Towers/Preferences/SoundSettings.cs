using UnityEngine;

[CreateAssetMenu(fileName = "Sound Settings", menuName = "Sound/Sound Settings/Create Sound Settings", order = 51)]
public class SoundSettings : ScriptableObject
{
    [SerializeField] private float _volume;
    [SerializeField] private float _pitch;
    [SerializeField] private AudioClip[] _sounds;

    public float Volume => _volume;
    public float Pitch => _pitch;
    public AudioClip[] Sounds => _sounds;
}
