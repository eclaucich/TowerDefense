using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    [SerializeField] protected bool canBuild = true;
    [SerializeField] protected bool isPath = false;

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

    private void OnMouseEnter() 
    {
        if(Builder.instance.selectedTurret != null)
            GetComponent<MeshRenderer>().material.color = canBuild?canBuildColor:cantBuildColor;    
    }

    private void OnMouseExit() 
    {
        if(!isPath)
            GetComponent<MeshRenderer>().material.color = normalColor;
        else
            GetComponent<MeshRenderer>().material.color = pathColor;
    }

    public void OnMouseDown()
    {
        if(canBuild)
            Builder.instance.BuildTurret(transform.position);
    }
    
}
