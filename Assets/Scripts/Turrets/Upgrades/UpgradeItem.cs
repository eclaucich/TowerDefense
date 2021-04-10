using UnityEngine;
using UnityEngine.UI;

/*

Represents the UI for a turret upgrade

*/

public class UpgradeItem : MonoBehaviour
{
    [SerializeField] private Text upgradeName;
    [SerializeField] private Text upgradePrice;
    [SerializeField] private Text upgradeDescription;
    [SerializeField] private Button upgradeButton;

    private TurretUpgrade turretUpgrade = null;

    public void SetUpgradeItem(TurretUpgrade turretUpgrade_)
    {
        turretUpgrade = turretUpgrade_;

        upgradeName.text = turretUpgrade.GetName();
        upgradePrice.text = "$" + turretUpgrade.GetPrice().ToString();
        upgradeDescription.text = turretUpgrade.GetDescription();
    }

    private void FixedUpdate() 
    {
        if(turretUpgrade==null)    
            return;
        
        upgradeName.text = turretUpgrade.GetName();

        if(turretUpgrade.currentUpgradeLevel >= turretUpgrade.GetMaxUpgradeLevel())
        {
            upgradeButton.interactable = false;
            upgradePrice.text = "-";    
            upgradeDescription.text = "UPGRADE MAX OUT";
        }
        else
        {
            upgradeButton.interactable = turretUpgrade.GetPrice() > GameController.instance.currentMoney ? false : true;
            upgradePrice.text = "$" + turretUpgrade.GetPrice().ToString();
            upgradeDescription.text = turretUpgrade.GetDescription();
        }
    }

    public void UpgradeTurret()
    {
        turretUpgrade.UpgradeTurret();
    }
}
