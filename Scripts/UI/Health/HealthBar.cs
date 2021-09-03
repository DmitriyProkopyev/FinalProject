using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Health _healthToShow;
    [SerializeField] private float _changingDuration;

    private Slider _slider;
    private Color _color;

    private void Start()
    {
        _healthToShow.HealthChanged += OnHealthChanged;
        _slider = GetComponent<Slider>();
        _color = _image.color;
        _slider.value = _healthToShow.Value;
    }

    public void OnHealthChanged()
    {
        float health = _healthToShow.Value;
        float maxHealth = _healthToShow.MaxHealth;
        float normalizedHealth = health / maxHealth;

        if (health <= 0)
        {
            _healthToShow.HealthChanged -= OnHealthChanged;
            return;
        }

        if (health > maxHealth)
            return;

        _image.DOColor(Color.Lerp(Color.red, Color.green, normalizedHealth), _changingDuration);
        _slider.DOValue(normalizedHealth, _changingDuration);
    }

    private void Update()
    {
        Vector3 direction = Camera.main.transform.forward;
        transform.parent.forward = -direction;
    }

    private void OnDestroy()
    {
        DOTween.Pause(gameObject);
    }
}
