using UnityEngine;
using UnityEngine.UI;

/*

Script attached to every Text component for setting the corresponding font

*/

public class TextUI : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Text>().font = GameController.instance.uiTextFont;
    }

}
