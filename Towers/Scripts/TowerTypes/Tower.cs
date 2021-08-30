using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public TowerPlace Place { get; private set; }

    public abstract TowerPreference GetPreference();

    private void Initialize(TowerPlace place)
    {
        Place = place;
        Initialize();
    }

    protected abstract void Initialize();

    public static void CreateNew(Tower template, TowerPlace place)
    {
        if (MoneyStorage.TrySpendMoney(template.GetPreference().View.Price))
        {
            if (place.TryTakePosition(out Vector3 position))
            {
                var tower = Instantiate(template, position, Quaternion.identity);
                tower.Initialize(place);
            }
            else
                throw new System.Exception("Place is not free");
        }
        else
            throw new System.Exception($"Not enough money to set {template.gameObject.name}!");
    }

    public void Delete()
    {
        Place.LeavePosition();
        Destroy(gameObject);
    }
}
