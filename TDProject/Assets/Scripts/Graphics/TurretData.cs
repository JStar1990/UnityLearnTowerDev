using UnityEngine;

[System.Serializable]
public class TurretData 
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradePrefab;
    public int costUpgraded;
    public TurretType tyep;
}
public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandarTurret
}
