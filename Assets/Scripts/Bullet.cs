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
    }

    public void Reverse()
    {
        rb.velocity = -rb.velocity*5;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = reversedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Detected " + collider.gameObject.tag);
        Health healthComponent = collider.gameObject.GetComponent<Health>();

        if (healthComponent && collider.gameObject.tag == subject)
        {
            Debug.Log("Hit " + subject);
            healthComponent.HealthDown(damage);
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Shield")
        {
            Debug.Log("Reverse Bullet");
            ChangeSubject();
            Reverse();
            return;
        }
    }

    private void ChangeSubject()
    {
        subject = "Enemy";
    }
}
