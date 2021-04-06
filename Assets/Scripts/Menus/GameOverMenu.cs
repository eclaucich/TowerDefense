using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Text currentWaveText;

    private void FixedUpdate() 
    {
        if(gameObject.activeSelf)
            currentWaveText.text = $"Waves completed: {GameController.instance.currentWave-1}";    
    }
}
