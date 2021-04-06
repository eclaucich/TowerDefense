using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Text bestWaveText;

    private void FixedUpdate() 
    {
        bestWaveText.text = $"Best wave: {GameController.instance.bestWave}";
    }    
}
