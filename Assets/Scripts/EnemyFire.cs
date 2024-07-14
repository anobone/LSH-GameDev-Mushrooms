using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    int health;
    [Header("Временной промежуток создания пулек")]
    [SerializeField] float time1; [SerializeField] float time2;
    float nextTimeSpawn;

    private void Start()
    {
        if (time1==time2 && time2 == 0)
        {
            time1 = 2; time2 = 5;
        }
        nextTimeSpawn = RandomizeSpawnTime(time1, time2);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTimeSpawn)
        {
            Bullet bulletClone;
            //GameObject bulletClone = bullet;
            bulletClone = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            //bulletClone.SetTarget();
            //bullet.getParent = transform;
            nextTimeSpawn = RandomizeSpawnTime(time1, time2);
        }
    }

    float RandomizeSpawnTime(float timestamp1, float timestamp2)
    {
        float nextTime = Time.time + Random.Range(timestamp1, timestamp2);
        return nextTime;
    }
}
