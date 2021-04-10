using System.Collections.Generic;
using UnityEngine;

/*

Singleton of the map of the game (the game is thinked to be played in only one map)

*/

public class Map : MonoBehaviour
{
    public static Map instance = null;

    [SerializeField] private List<Transform> waypoints;     // List of the waypoints that enemies will follow 

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
