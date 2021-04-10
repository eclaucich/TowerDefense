using UnityEngine;
using UnityEngine.UI;

/*

Menu showed when the game starts

*/

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Text bestWaveText;

    private void FixedUpdate() 
    {
        bestWaveText.text = $"Best wave: {GameController.instance.bestWave}";
    }    
}
