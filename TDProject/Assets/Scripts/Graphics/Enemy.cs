using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    private Transform[] _positions;
    private int _index = 0;
    public int Speed = 10;
    public int hp = 100;
    private int max_hp = 0;
    private Slider hp_pro;
    // Start is called before the first frame update
    void Start()
    {
        _positions = WayPoints.positions;
        max_hp = hp;
        hp_pro = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _move();
    }

    void _move ()
    {
        if (_index >= _positions.Length) return;
        transform.Translate((_positions[_index].position - transform.position).normalized * Time.deltaTime * Speed);
        
        if ( Vector3.Distance(_positions[_index].position, transform.position)<0.2f)
        {
            ++_index;
        }

        if ( _index >= _positions.Length)
        {
            ReachDestination();
        }
    }

    void ReachDestination ()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage (int damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        if (hp<=0)
        {
            Die();
        }
        hp_pro.value = hp * 1.0f / max_hp;
    }

    void Die ()
    {
        hp = 0;
        // 播放死亡特效
        // 移除自己
        Destroy(this.gameObject);
    }
}
