using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private string turretName;
    [SerializeField] private int turretPrice;
    protected int currentTurretValue;

    [Space]
    [Header("Range Zone")]
    [SerializeField] private GameObject rangeZone;
    [SerializeField] protected float range = 4f;
    private Transform target = null;

    [Space]
    [Header("Rotation")]
    [SerializeField] private Transform rotatingPoint;
    [SerializeField] private float rotationSpeed = 10f; 

    [Space]
    [Header("Firing")]
    [SerializeField] protected int damage = 1;
    [SerializeField] protected Transform firingPoint;
    [SerializeField] protected float firingSpeed;
    [SerializeField] protected Bullet bulletPrefab;
    private float currentFiringTime = 0f;

    [SerializeField] protected List<TurretUpgrade> upgrades;

    virtual public void Start() 
    {
        rangeZone.SetActive(false);    
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        Vector3 scaleRangeZone = new Vector3(range*2, 0.01f, range*2);
        rangeZone.transform.localScale = scaleRangeZone;

        currentFiringTime = 1/firingSpeed;

        upgrades = new List<TurretUpgrade>();

        currentTurretValue = turretPrice;
    }

    private void Update() 
    {
        if(GameController.instance.gameState == GameController.GameState.playing)
        {
            if(target == null)
            return;

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(rotatingPoint.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
            rotatingPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            currentFiringTime += Time.deltaTime;

            if(currentFiringTime >= 1/firingSpeed)
            {
                Fire();
                currentFiringTime = 0f;
            }
        }
    }

    private void UpdateTarget()
    {
        if(GameController.instance.gameState == GameController.GameState.playing)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (var enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if(distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if(nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }

    protected virtual void Fire()
    {
        Bullet bulletGO = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        bulletGO.SetTarget(target, damage);
    }

    public void SellTurret()
    {
        GameController.instance.currentMoney += GetCurrentSellAmount();
        Instantiate(GameController.instance.sellTowerParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnMouseDown() 
    {
        UpgradeMenu.instance.OpenUpdgrades(this);
    }

    public void ShowRangeZone(bool state)
    {
        rangeZone.SetActive(state);
    }

    public void ChangeRange(float amount)
    {
        range += amount;

        Vector3 scaleRangeZone = new Vector3(range*2, 0.01f, range*2);
        rangeZone.transform.localScale = scaleRangeZone;
    }

    public int GetCurrentSellAmount()
    {
        return (int)(currentTurretValue*GameController.instance.sellPercentage);
    }

    public string GetName()
    {
        return turretName;
    }

    public int GetPrice()
    {
        return turretPrice;
    }

    public List<TurretUpgrade> GetUpgrades()
    {
        return upgrades;
    }
}
