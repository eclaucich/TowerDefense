using UnityEngine;

/*

Singleton that handles building the current selected turret

*/

public class Builder : MonoBehaviour
{
    public static Builder instance = null;

    [HideInInspector] public Turret selectedTurret = null;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start() 
    {
        selectedTurret = null;
    }

    /// Called after clicking on a valid building block
    /// Instantiate the selected turret on top of the building block clicked
    public void BuildTurret(Vector3 position)
    {
        if(selectedTurret!=null)
        {
            Turret turretGO = Instantiate(selectedTurret, position, Quaternion.identity);
            Instantiate(GameController.instance.createTowerParticle, turretGO.transform, false);
            GameController.instance.currentMoney -= selectedTurret.GetPrice();
            selectedTurret = null;
        }
    }
}
