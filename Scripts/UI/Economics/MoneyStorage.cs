using UnityEngine.Events;
using UnityEngine;

public static class MoneyStorage
{
    private static uint _money;
    private static uint _moneyOnStart = 12000;

    public static event UnityAction<uint> MoneyChanged;

    public static void Initialize()
    {
        _money = _moneyOnStart;
        MoneyChanged?.Invoke(_money);
    }

    public static void AddMoney(uint money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public static bool TrySpendMoney(uint money)
    {
        if (IsEnough(money))
        {
            _money -= money;
            MoneyChanged?.Invoke(_money);
            return true;
        }

        return false;
    }

    public static bool IsEnough(uint money) => _money >= money;
}
