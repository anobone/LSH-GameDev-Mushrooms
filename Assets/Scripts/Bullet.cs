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
    bool reversed = false;
    //GameObject playerHealth;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        Debug.LogError("Detected " + collider.gameObject.tag);
        Health healthComponent = collider.gameObject.GetComponent<Health>();

        if (healthComponent && collider.gameObject.tag == subject)
        {
            Debug.Log("Hit " + subject);
            healthComponent.HealthDown(damage);
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Shield" && !reversed)
        {
            reversed = true;
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
