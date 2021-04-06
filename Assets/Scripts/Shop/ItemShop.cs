using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    [SerializeField] private Button button;

    [Header("Info")]
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemPrice;

    private Turret turretReference = null;

    private void FixedUpdate() 
    {
        if(turretReference!=null)
            button.interactable = GameController.instance.currentMoney>=turretReference.GetPrice() ? true:false;
    }

    public void SetItemShop(Turret turret)
    {
        itemName.text = turret.GetName();
        itemPrice.text = "$" + turret.GetPrice();
        turretReference = turret;
    }

    public void SelectItem()
    {
        Builder.instance.selectedTurret = turretReference; 
    }
}
