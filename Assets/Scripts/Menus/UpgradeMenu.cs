using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu instance = null;

    [SerializeField] private UpgradeItem upgradeItemPrefab;
    [SerializeField] private Shop shop;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Text sellAmountText;

    private Turret selectedTurret = null;
    private List<UpgradeItem> listPrefabs;

    private void Awake() 
    {
        if(instance==null)
            instance = this;
        else
            Destroy(this);  

        listPrefabs = new List<UpgradeItem>(); 
    }

    private void FixedUpdate() 
    {
        if(selectedTurret!=null)
            sellAmountText.text = $"${selectedTurret.GetCurrentSellAmount()}";    
    }

    public void OpenUpdgrades(Turret turret)
    {
        if(turret==selectedTurret)
            return;
        
        if(selectedTurret!=null)
            selectedTurret.ShowRangeZone(false);

        selectedTurret = turret;
        selectedTurret.ShowRangeZone(true);

        shop.gameObject.SetActive(false);
        gameObject.SetActive(true);

        sellAmountText.text = $"${selectedTurret.GetCurrentSellAmount()}";

        foreach (var prefab in listPrefabs)
        {
            Destroy(prefab.gameObject);
        }
        listPrefabs.Clear();

        foreach (var upgrade in selectedTurret.GetUpgrades())
        {
            UpgradeItem upgradeItemGO = Instantiate(upgradeItemPrefab, parentTransform, false);
            upgradeItemGO.gameObject.SetActive(true);
            upgradeItemGO.SetUpgradeItem(upgrade);
            listPrefabs.Add(upgradeItemGO);
        }
    }

    public void CloseUpgradesMenu()
    {
        shop.gameObject.SetActive(true);
        gameObject.SetActive(false);

        selectedTurret.ShowRangeZone(false);
        selectedTurret = null;
    }

    public void SellTurret()
    {
        selectedTurret.SellTurret();
        CloseUpgradesMenu();
    }
}