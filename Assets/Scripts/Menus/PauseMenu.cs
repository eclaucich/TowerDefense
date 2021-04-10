using UnityEngine;
using UnityEngine.UI;

/*

Menu showed when the player pause the game

*/
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Text currentWaveText;

    private void FixedUpdate() 
    {
        if(gameObject.activeSelf)
            currentWaveText.text = $"Current wave: {GameController.instance.currentWave}";    
    }
}
