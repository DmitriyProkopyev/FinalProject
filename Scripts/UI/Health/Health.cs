using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float Value { get; private set; }
    public float MaxHealth { get; private set; }

    public event UnityAction HealthChanged;

    public void Initialize(float maxHealth)
    {
        MaxHealth = maxHealth;
        Value = maxHealth;
        HealthChanged?.Invoke();
    }

    public void Heal(float value)
    {
        if (value <= 0)
            return;
        Value += value;
        Value = Mathf.Clamp(Value, 0, MaxHealth);
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float value)
    {
        if (value <= 0)
            return;
        Value -= value;
        Value = Mathf.Clamp(Value, 0, MaxHealth);
        HealthChanged?.Invoke();
    }
}
