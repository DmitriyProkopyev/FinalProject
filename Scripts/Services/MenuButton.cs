using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public abstract class MenuButton : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private Button _button;
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _clip;
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        _audioSource.Play();
        OnClick();
    }

    protected abstract void OnClick();
}