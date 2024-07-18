using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y 
            - transform.position.y + player.transform.GetComponent<SpriteRenderer>().bounds.size.y/2);
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
        Health healthComponent = collider.gameObject.GetComponent<Health>();

        /*Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
        if (healthComponent && collider.gameObject.tag == subject)
        {
            healthComponent.HealthDown(damage);

            if (subject.Equals("Player"))
            {
                SpriteRenderer blob = null;
                for (int i = 0; i < collider.transform.childCount; i++)
                {
                    if (collider.transform.GetChild(i).CompareTag("Blob"))
                    {
                        blob = collider.transform.GetChild(i).GetComponent<SpriteRenderer>();
                        break;
                    }
                }
                healthComponent.StartCoroutine(BlobDissapear(blob));
                if (healthComponent.IsDead())
                {
                    GameManager.Instance.ShowLoseScreen();
                }   
            }
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Shield" && !reversed)
        {
            reversed = true;
            ChangeSubject();
            Reverse();
            return;
        }
    }

    private void ChangeSubject()
    {
        subject = "Enemy";
    }

    IEnumerator BlobDissapear(SpriteRenderer blob)
    {
        for (int i = 0; i <= 10; i++)
        {
            Color blobColor = blob.color;
            blobColor.a = ((float)10 - i) * 0.1f;
            blob.color = blobColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
