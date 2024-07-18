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
        Health healthComponent = collider.gameObject.GetComponent<Health>();

        if (healthComponent && collider.gameObject.tag == subject)
        {
            healthComponent.HealthDown(damage);

            if (subject.Equals("Player"))
            {
                SpriteRenderer blob = null;
                for (int i = 0; i < collider.transform.childCount; i++)
                {
                    //Debug.Log(collider.transform.childCount);
                    if (collider.transform.GetChild(i).CompareTag("Blob"))
                    {
                        blob = collider.transform.GetChild(i).GetComponent<SpriteRenderer>();
                        break;
                    }
                }
                StartCoroutine(BlobDissapear(blob));
                Debug.Log(blob.name);
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
        float i = 0;
        while (i <= 4)
        {
            i += Time.deltaTime;
            Color blobColor = blob.color;
            blobColor.a = ((float)10 - i) * 0.1f;
            Debug.Log(blobColor.a);
            blob.color = blobColor;
            yield return null;
        }
        //yield return null;
    }
}
