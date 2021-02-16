using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;           
        }
        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.moneyCost; } }

    public GameObject buildEffect;
    public void BuildTurretOn (TowerBuildingSpot towerBuildingSpot)
    {
        if (PlayerStats.Money < turretToBuild.moneyCost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.moneyCost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, towerBuildingSpot.GetBuildPosition(), Quaternion.identity);
        towerBuildingSpot.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, towerBuildingSpot.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);

    }
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
