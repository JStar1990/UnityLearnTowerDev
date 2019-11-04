using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Dev.debug;

public class BuilderManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    private TurretData selectedTurretData;

    private int _money = 5000;

    void ChangeMoney (int change)
    {
        _money += change;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if(isCollider)
                {
                    MapCube mapCube = hit.collider.gameObject.GetComponent<MapCube>();
                    if (mapCube != null)
                    {
                        if (selectedTurretData != null && mapCube.turrentGo == null)
                        {
                            if (_money >= selectedTurretData.cost)
                            {
                                ChangeMoney(-selectedTurretData.cost);
                                mapCube.BuildTurret(selectedTurretData.turretPrefab);
                            }
                        }
                        else if (mapCube.turrentGo != null)
                        {

                        }
                    }
                }
            }
        }
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn) selectedTurretData = laserTurretData;
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn) selectedTurretData = missileTurretData;
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn) selectedTurretData = standardTurretData;
    }
}
