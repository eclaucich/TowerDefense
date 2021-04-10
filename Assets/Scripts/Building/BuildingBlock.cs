using UnityEngine;

/*

Blocks where turrets could be placed

*/

public class BuildingBlock : MonoBehaviour
{
    [SerializeField] protected bool canBuild = true;    //Set if player can build on top of this block (usefull to be change dinamically through the game)
    [SerializeField] protected bool isPath = false;     //TODO: make a separate class for this (it will never be a building block)

    [Space]
    [Header("Colors")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color canBuildColor;
    [SerializeField] private Color cantBuildColor;
    [SerializeField] private Color pathColor;

    private void Start() 
    {
        if(isPath)
        {
            canBuild = false;
            GetComponent<MeshRenderer>().material.color = pathColor;
        }
        else
            GetComponent<MeshRenderer>().material.color = normalColor;
    }

    // Chance the hover color of the block based on if its buildable of not
    private void OnMouseEnter() 
    {
        if(Builder.instance.selectedTurret != null)
            GetComponent<MeshRenderer>().material.color = canBuild?canBuildColor:cantBuildColor;    
    }

    // Returns color to normal when the mouse is not hovering the block
    private void OnMouseExit() 
    {
        if(!isPath)
            GetComponent<MeshRenderer>().material.color = normalColor;
        else
            GetComponent<MeshRenderer>().material.color = pathColor;
    }

    // Call the builder on mouse click if its possible
    public void OnMouseDown()
    {
        if(canBuild)
            Builder.instance.BuildTurret(transform.position);
    }
    
}
