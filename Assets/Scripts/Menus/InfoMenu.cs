using UnityEngine;
using UnityEngine.UI;

/*

Menu that shows important information to the player

*/

public class InfoMenu : MonoBehaviour
{
    [SerializeField] private Text wavesText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text moneyText;

    private void Start() 
    {
        SetTexts();
    }

    private void FixedUpdate() 
    {
        SetTexts();
    }

    private void SetTexts()
    {
        wavesText.text = "Wave: " + GameController.instance.currentWave.ToString();
        livesText.text = "Lives: " + GameController.instance.currentLives.ToString();
        moneyText.text = "Money: $" + GameController.instance.currentMoney.ToString();
    }
}
