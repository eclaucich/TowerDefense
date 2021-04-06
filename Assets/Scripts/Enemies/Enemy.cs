using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected int lives = 1;
    [SerializeField] protected int priceMoney = 10;
    [SerializeField] protected int minWave = 0;

    private int currentWaypointIndex = 1;
    private Transform currentWaypoint = null;

    private void Update() 
    {
        if(GameController.instance.gameState == GameController.GameState.playing)
        {
            if(currentWaypoint!=null)
            {
                transform.position = Vector3.MoveTowards(transform.position, Map.instance.GetWaypointAtIndex(currentWaypointIndex).position, speed*Time.deltaTime);

                if(Vector3.Distance(transform.position, currentWaypoint.position)<=0.01f)
                {
                    if(currentWaypointIndex == Map.instance.GetNumberOfWaypoints()-1)
                    {
                        GameController.instance.currentLives -= 1;
                        Instantiate(GameController.instance.damageBaseParticle, transform.position, Quaternion.identity);
                        Destroy(this.gameObject);
                        return;
                    }
                    currentWaypointIndex+=1;
                    currentWaypoint = Map.instance.GetWaypointAtIndex(currentWaypointIndex);
                }
            }
        }
    }

    public void SetCurrentWaypoint(Transform waypoint)
    {
        currentWaypoint = waypoint;
    }

    public void Damage(int amount)
    {
        lives -= amount;
        if(lives <= 0)
        {
            GameController.instance.currentMoney += priceMoney;
            Instantiate(GameController.instance.enemyDeathParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public int GetMinWave()
    {
        return minWave;
    }
}
