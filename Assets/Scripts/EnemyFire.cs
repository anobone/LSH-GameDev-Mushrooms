using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [Header("Time period for creating bullets")]
    [SerializeField] float time1; [SerializeField] float time2;
    [SerializeField] GameManager conditions;
    float nextTimeSpawn;
    Health enemyHealth;
    Animator enemyAnimator;
    float TreeDamage = 100f;

    private void Start()
    {
        if (time1==time2 && time2 == 0)
        {
            time1 = 2; time2 = 5;
        }
        nextTimeSpawn = RandomizeSpawnTime(time1, time2);
        enemyHealth = GetComponent<Health>();
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(Time.time +" " + nextTimeSpawn);
        if (Time.time > nextTimeSpawn)
        {
            enemyAnimator.SetTrigger("Spit");
            Bullet bulletClone;
            bulletClone = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            nextTimeSpawn = RandomizeSpawnTime(time1, time2);
        }
        if (enemyHealth.GetRemainingHealth <= 0)
        {
            Death();
        }
    }

    float RandomizeSpawnTime(float timestamp1, float timestamp2)
    {
        float nextTime = Time.time + Random.Range(timestamp1, timestamp2);
        return nextTime;
    }

    void Death()
    {
        GameManager.Instance.DecrementEnemies();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            enemyHealth.HealthDown(TreeDamage);
        }
    }

}
