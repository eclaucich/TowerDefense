using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Text currentWaveText;

    private void FixedUpdate() 
    {
        if(gameObject.activeSelf)
            currentWaveText.text = $"Current wave: {GameController.instance.currentWave}";    
    }
}
