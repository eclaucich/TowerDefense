using UnityEngine;

/*

A tall turret, nothing special

*/

public class TurretTall : Turret
{
    [Space]
    [Header("Damage")]
    [Header("Upgrades")]
    [SerializeField] private int damageUpgrade = 1;
    [SerializeField] private int damageUpgradeCost = 100;
    [SerializeField] private int damageUpgradeMaxLevel = 3;


    /// Set all the available upgrades for this turret
    override public void Start() 
    {
        base.Start();
        
        TurretUpgrade turretUpgrade = new TurretUpgrade("Damage", $"Upgrade damage from {damage} to {damage+damageUpgrade}", damageUpgradeCost, UpgradeDamage, damageUpgradeMaxLevel);    
        upgrades.Add(turretUpgrade);
    }

    /// The next method defines the functionality behind each upgrade
    public void UpgradeDamage()
    {
        upgrades[0].currentUpgradeLevel++;
        currentTurretValue += damageUpgradeCost;
        damage += damageUpgrade;
        GameController.instance.currentMoney -= damageUpgradeCost;
        upgrades[0].UpdateDescription($"Upgrade damage from {damage} to {damage+damageUpgrade}");
    }
}
