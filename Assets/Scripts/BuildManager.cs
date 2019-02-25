using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject MissileLauncherPrefab;

    private Shop.TurretBlueprint turretToBuild;

    //void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}

    public bool CanBuild { get { return turretToBuild != null; } }

    //public Shop.TurretBlueprint GetTurretToBuild()
    //{
    //    return turretToBuild;
    //}
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Build successfully! left money: " + PlayerStats.Money);
    }


    public void SelectTurretToBuild(Shop.TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
