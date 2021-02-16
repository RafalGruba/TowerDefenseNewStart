using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint laserBeamer; // Tesla

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("standard turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("another turret purchased");
        buildManager.SelectTurretToBuild(anotherTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer purchased");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}

