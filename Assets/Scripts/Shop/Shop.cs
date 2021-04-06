using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ItemShop itemShopPrefab;
    [SerializeField] private Transform parentTransform;

    private void Start() 
    {
        foreach (var turret in GameController.instance.turrets)
        {
            ItemShop itemGO = Instantiate(itemShopPrefab, parentTransform, false);
            itemGO.SetItemShop(turret);
            itemGO.gameObject.SetActive(true);
        }
    }
}
