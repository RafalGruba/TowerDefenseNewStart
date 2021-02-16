using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerBuildingSpot : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor; 
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private SpriteRenderer rend;
    private Color startColor;
    BuildManager buildManager;

   

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        buildManager.BuildTurretOn(this);
        
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.color = hoverColor;
        }
        else
        {
            rend.color = notEnoughMoneyColor;
        }

        Debug.Log("change of color");


    }

    void OnMouseExit()
    {

        rend.color = startColor;
    }


}

