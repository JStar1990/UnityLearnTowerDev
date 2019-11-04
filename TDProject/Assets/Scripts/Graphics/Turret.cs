using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }

    public float attackRateTime = 1;
    private float timer = 0;

    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform head;

    private void Start()
    {
        timer = 1.0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if ( enemys.Count > 0 && timer >= attackRateTime )
        {
            timer = 0;
            Attack();
        }
        if (enemys.Count > 0&&enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
    }

    void Attack ()
    {
        if(enemys[0] == null)
        {
            updateEnemy();
        }
        if (enemys.Count == 0)
        {
            timer = attackRateTime;
        }
        else
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
    }

    void updateEnemy()
    {
        for(int i = enemys.Count - 1; i >= 0; --i)
        {
            if(enemys[i] == null)
            {
                enemys.RemoveAt(i);
            }
        }
    }
}
