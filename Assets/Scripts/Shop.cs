using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    public GameObject buildEffect;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Another Missile Launcher");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    [System.Serializable]
    public class TurretBlueprint
    {

        public GameObject prefab;
        public int cost;

        //public GameObject upgradedPrefab;
        //public int upgradeCost;

        //public int GetSellAmount()
        //{
        //    return cost / 2;
        //}

    }
}
