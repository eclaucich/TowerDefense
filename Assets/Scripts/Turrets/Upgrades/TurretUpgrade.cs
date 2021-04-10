/*

Base class that represents a generic upgrade for any turret 
    upgradeName -> name that represents this upgrade
    price -> money needed to be bought
    description -> explains what the upgrade does
    rateCostIncrease -> rate at what the cost of the upgrade will increase (between each upgrade level)
    currentUpgradeLevel -> current level of the upgrade
    maxUpgradeLevel -> level at with the upgrade will be max out
*/
public class TurretUpgrade
{
    private string upgradeName;
    private int price;
    private string description;
    private float rateCostIncrease;
    public int currentUpgradeLevel;
    private int maxUpgradeLevel;

    public delegate void Upgrade();
    private Upgrade upgradeMethod;


    
    public TurretUpgrade(string upgradeName_, string description_, int price_, Upgrade upgradeMethod_, int maxUpgradeLevel_)
    {
        upgradeName = upgradeName_;
        description = description_;
        price = price_;
        upgradeMethod = upgradeMethod_;
        currentUpgradeLevel = 0;
        maxUpgradeLevel = maxUpgradeLevel_;
        rateCostIncrease = GameController.instance.rateUpgradesCostIncrease;
    }

    public void UpgradeTurret()
    {
        upgradeMethod();
    }

    public void NextLevel()
    {
        currentUpgradeLevel++;
        price = (int)(price * (1.0f+rateCostIncrease));
    }


#region Setters
    public void UpdateDescription(string newDescription)
    {
        description = newDescription;
    }

    public void UpdatePrice(int newPrice)
    {
        price = newPrice;
    }
#endregion


#region Getters
    public string GetName()
    {
        return upgradeName;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetPrice()
    {
        return price;
    }

    public Upgrade GetUpgradeMethod()
    {
        return upgradeMethod;
    }

    public int GetMaxUpgradeLevel()
    {
        return maxUpgradeLevel;
    }
#endregion
}
