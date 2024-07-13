using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float damagePercent;
    string subject = "Player";
    GameObject playerHealth;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag(subject);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * force;
        playerHealth = GameObject.FindGameObjectWithTag("Health");
        //print(player);
    }

    public void Reverse()
    {
        rb.velocity = -rb.velocity*10;
    }
    /*private void OnCollisionEnter2D(Collision2D shielded)
    {
        Debug.Log(shielded);
        if (shielded.gameObject.tag == "Player")
        {
            Debug.Log("Detected Player");
            if (shielded.collider.isTrigger == true)
            {
                Debug.Log("Reverse Bullet");
                Reverse();
            }
            else
            {
                Debug.Log("Hit player");
            }
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Detected Something");
        if (collider.gameObject.tag == subject)
        {
            Debug.Log("Hit " + subject);
            playerHealth.GetComponent<Health>().HealthDown(damagePercent);
            //по хорошему это надо переписать
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Shield")
        {
            Debug.Log("Reverse Bullet");
            ChangeSubject();
            Reverse();
        }
    }

    private void ChangeSubject()
    {
        subject = "Enemy";
    }
}
