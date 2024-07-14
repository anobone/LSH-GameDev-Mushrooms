using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float damage;
    string subject = "Player";
    [SerializeField] Sprite reversedBullet;
    //GameObject playerHealth;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag(subject);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * force;
        //playerHealth = GameObject.FindGameObjectWithTag("Health");
        //print(player);
    }

    public void Reverse()
    {
        rb.velocity = -rb.velocity*10;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = reversedBullet;
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
        Debug.Log("Detected " + collider.gameObject.tag);
        Health healthComponent = collider.gameObject.GetComponent<Health>();

        if (collider.gameObject.tag == "Shield")
        {
            Debug.Log("Reverse Bullet");
            ChangeSubject();
            Reverse();
            return;
        }
        if (healthComponent && collider.gameObject.tag == subject)
        {
            Debug.Log("Hit " + subject);
            healthComponent.HealthDown(damage);
            //по хорошему это надо переписать
            Destroy(gameObject);
        }
    }

    private void ChangeSubject()
    {
        subject = "Enemy";
    }
}
