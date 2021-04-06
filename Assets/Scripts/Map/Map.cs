using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance = null;

    [SerializeField] private List<Transform> waypoints;

    private void Awake() 
    {
        if(instance==null)
            instance = this;
        else
            Destroy(this);    
    }

    public Transform GetWaypointAtIndex(int index)
    {
        return waypoints[index];
    }

    public int GetNumberOfWaypoints()
    {
        return waypoints.Count;
    }

    public Transform GetEnemySpawn()
    {
        return waypoints[0];
    }
}
