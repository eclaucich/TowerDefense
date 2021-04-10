using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*

Singleton that handles core functionallity of the game.
It holds global game properties and global prefabs

*/

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public List<Turret> turrets;

    [HideInInspector] public int currentWave;
    [HideInInspector] public int currentLives;
    [HideInInspector] public int currentMoney;
    [HideInInspector] public int bestWave = 0;

    [Header("Fonts")]
    [SerializeField] public Font uiTextFont;
    
    [Space]
    [Header("Game properties")]
    [SerializeField] private int startingLives = 100;
    [SerializeField] private int startingMoney = 50;
    public GameState gameState;
    [RangeAttribute(0f, 1f)] public float sellPercentage = .3f;
    [RangeAttribute(0f, 1f)] public float rateUpgradesCostIncrease = .2f;

    [Space]
    [Header("Menus")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Shop shop;
    [SerializeField] private UpgradeMenu upgradeMenu;

    [Space]
    [Header("Particles")]
    [SerializeField] public ParticleSystem createTowerParticle;
    [SerializeField] public ParticleSystem sellTowerParticle;
    [SerializeField] public ParticleSystem upgradeTowerParticle;
    [SerializeField] public ParticleSystem spawnEnemyParticle;
    [SerializeField] public ParticleSystem enemyDeathParticle;
    [SerializeField] public ParticleSystem bulletHitParticle;
    [SerializeField] public ParticleSystem damageBaseParticle;


    public enum GameState
    {
        start,
        playing,
        pause,
        gameover
    };

    private void Awake() 
    {
        if(instance==null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start() 
    {
        ChangeGameState(GameState.start);
        shop.gameObject.SetActive(true);
        upgradeMenu.gameObject.SetActive(false);
        GameController.instance.bestWave = LoadSystem.LoadBestWave();
    }

    /// Checks if the game is over
    private void FixedUpdate() 
    {
        if(currentLives <= 0)
        {
            if (currentWave >= bestWave)
                SaveSystem.SaveBestWave(currentWave-1);
            ChangeGameState(GameState.gameover);
        }    
    }

    /// Handles the differents game states
    public void ChangeGameState(GameController.GameState newGameState)
    {
        gameState = newGameState;

        switch(gameState)
        {
            case GameState.start:
                startMenu.SetActive(true);
                pauseMenu.SetActive(false);
                gameOverMenu.SetActive(false);
                break;
            
            case GameState.pause:
                startMenu.SetActive(false);
                pauseMenu.SetActive(true);
                gameOverMenu.SetActive(false);
                break;
            
            case GameState.playing:
                startMenu.SetActive(false);
                pauseMenu.SetActive(false);
                gameOverMenu.SetActive(false);
                break;

            case GameState.gameover:
                startMenu.SetActive(false);
                pauseMenu.SetActive(false);
                gameOverMenu.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void StartGame()
    {
        ChangeGameState(GameState.playing);
        currentWave = 0;
        currentLives = startingLives;
        currentMoney = startingMoney;
    }

    public void PauseGame()
    {
        ChangeGameState(GameState.pause);
    }

    public void ResumeGame()
    {
        ChangeGameState(GameState.playing);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
