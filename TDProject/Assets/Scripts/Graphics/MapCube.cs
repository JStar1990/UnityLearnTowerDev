using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turrentGo;

    public GameObject buildEffect;

    private new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();   
    }

    public void BuildTurret ( GameObject prefab )
    {
        turrentGo = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }

    private void OnMouseEnter()
    {
        if ( turrentGo == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            renderer.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
