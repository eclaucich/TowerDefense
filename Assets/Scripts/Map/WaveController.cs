using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private List<Enemy> enemiesPrefabs;
    private List<Enemy> availableEnemies;

    [Space]
    [Header("Spawner")]
    [SerializeField] private float timeBtwEnemies = 1f;
    [SerializeField] private float timeBtwWaves = 3f;
    private float currentTimeBtwWaves;
    [SerializeField] private Button nextWaveButton;
    [SerializeField] private Text timeForNextWave;


    private void Start() 
    {
        currentTimeBtwWaves = timeBtwWaves;
        availableEnemies = new List<Enemy>();
        availableEnemies.Add(enemiesPrefabs[0]);
    }

    private void Update() 
    {
        if(GameController.instance.gameState == GameController.GameState.playing)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length==0)
            {
                nextWaveButton.interactable = true;
                currentTimeBtwWaves -= Time.deltaTime;
                timeForNextWave.text = ((int)currentTimeBtwWaves).ToString();

                if(currentTimeBtwWaves <= 0f)
                {
                    currentTimeBtwWaves = timeBtwWaves;
                    nextWaveButton.interactable = false;
                    StartCoroutine(SpawnNewWave());
                }
            }
        }    
    }

    public void ForceNextWave()
    {
        currentTimeBtwWaves = 0f;
    }

    private IEnumerator SpawnNewWave()
    {
        GameController.instance.currentWave++;

        //Control special cases for particular waves
        if (GameController.instance.currentWave == enemiesPrefabs[1].GetMinWave())
        {
            for (int i = 0; i < EnemyWaveIncreaseFunction(GameController.instance.currentWave); i++)
            {
                Enemy enemy_1 = Instantiate(enemiesPrefabs[1], Map.instance.GetEnemySpawn().position, Quaternion.identity);
                enemy_1.SetCurrentWaypoint(Map.instance.GetWaypointAtIndex(1));
                Instantiate(GameController.instance.spawnEnemyParticle, Map.instance.GetEnemySpawn().position, Quaternion.identity);
                yield return new WaitForSeconds(timeBtwEnemies);
            }
            availableEnemies.Add(enemiesPrefabs[1]);
        }
        else if (GameController.instance.currentWave == enemiesPrefabs[2].GetMinWave())
        {
            Enemy enemy_2 = Instantiate(enemiesPrefabs[2], Map.instance.GetEnemySpawn().position, Quaternion.identity);
            enemy_2.SetCurrentWaypoint(Map.instance.GetWaypointAtIndex(1));
            Instantiate(GameController.instance.spawnEnemyParticle, Map.instance.GetEnemySpawn().position, Quaternion.identity);
            availableEnemies.Add(enemiesPrefabs[2]);
        }
        else
        {
            for (int i = 0; i < EnemyWaveIncreaseFunction(GameController.instance.currentWave); i++)
            {
                int randomIndex = Random.Range(0, availableEnemies.Count);
                Enemy enemy_3 = Instantiate(enemiesPrefabs[randomIndex], Map.instance.GetEnemySpawn().position, Quaternion.identity);
                enemy_3.SetCurrentWaypoint(Map.instance.GetWaypointAtIndex(1));
                Instantiate(GameController.instance.spawnEnemyParticle, Map.instance.GetEnemySpawn().position, Quaternion.identity);
                yield return new WaitForSeconds(timeBtwEnemies);
            }
        }
    }

    private int EnemyWaveIncreaseFunction(int waveNumber)
    {
        return waveNumber*2;
    }
}
