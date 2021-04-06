using UnityEngine;

public class TurretNormal : Turret
{
    [Space]
    [Header("Upgrades")]
    [Header("Damage")]
    [SerializeField] private int damageUpgradeAmount = 1;
    [SerializeField] private int damageUpgradeCost = 50;
    [SerializeField] private int damageUpgradeMaxLevel = 3;
    
    [Header("Firing Speed")]
    [SerializeField] private float firingSpeedUpgradeAmount = .5f;
    [SerializeField] private int firingSpeedUpgradeCost = 10;
    [SerializeField] private int firingSpeedUpgradeMaxLevel = 2;

    [Header("Range")]
    [SerializeField] private float rangeUpgradeAmount = .5f;
    [SerializeField] private int rangeUpgradeCost = 30;
    [SerializeField] private int rangeUpgradeMaxLevel = 2;

    override public void Start() 
    {
        base.Start();
        
        TurretUpgrade damageUpgrade = new TurretUpgrade("Damage", $"Upgrade damage from {damage} to {damage+damageUpgradeAmount}", damageUpgradeCost, UpgradeDamage, damageUpgradeMaxLevel);    
        TurretUpgrade speedUpgrade = new TurretUpgrade("Firing Speed", $"Upgrade firing speed from {firingSpeed} to {firingSpeed+firingSpeedUpgradeAmount}", firingSpeedUpgradeCost, UpgradeFiringSpeed, firingSpeedUpgradeMaxLevel);    
        TurretUpgrade rangeUpgrade = new TurretUpgrade("Range", $"Upgrade range from {range} to {range+rangeUpgradeAmount}", rangeUpgradeCost, UpgradeRange, rangeUpgradeMaxLevel);

        upgrades.Add(damageUpgrade);
        upgrades.Add(speedUpgrade);
        upgrades.Add(rangeUpgrade);
    }

    private void UpgradeDamage()
    {
        Instantiate(GameController.instance.upgradeTowerParticle, transform, false);
        upgrades[0].NextLevel();
        currentTurretValue += damageUpgradeCost;
        damage += damageUpgradeAmount;
        GameController.instance.currentMoney -= damageUpgradeCost;
        upgrades[0].UpdateDescription($"Upgrade damage from {damage} to {damage+damageUpgradeAmount}");
    }

    private void UpgradeFiringSpeed()
    {
        Instantiate(GameController.instance.upgradeTowerParticle, transform, false);
        upgrades[1].NextLevel();
        currentTurretValue += firingSpeedUpgradeCost;
        firingSpeed += firingSpeedUpgradeAmount;
        GameController.instance.currentMoney -= firingSpeedUpgradeCost;
        upgrades[1].UpdateDescription($"Upgrade firing speed from {firingSpeed} to {firingSpeed+firingSpeedUpgradeAmount}");
    }

    private void UpgradeRange()
    {
        Instantiate(GameController.instance.upgradeTowerParticle, transform, false);
        upgrades[2].NextLevel();
        currentTurretValue += rangeUpgradeCost;
        ChangeRange(rangeUpgradeAmount);
        GameController.instance.currentMoney -= rangeUpgradeCost;
        upgrades[2].UpdateDescription($"Upgrade range from {range} to {range+rangeUpgradeAmount}");
    }
}
