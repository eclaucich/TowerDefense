using UnityEngine;
using UnityEngine.UI;

/*

Menu showed when the player's live reach to zero

*/
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Text currentWaveText;

    // Displays the last wave cleared (TODO: it doesnt need to be in a FixedUpdate)
    private void FixedUpdate() 
    {
        if(gameObject.activeSelf)
            currentWaveText.text = $"Waves completed: {GameController.instance.currentWave-1}";    
    }
}
