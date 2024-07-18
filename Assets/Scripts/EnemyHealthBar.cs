using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Transform healthBar;
    [SerializeField] Health characterHealth;
    float healthMax;
    float healthLeft;
    float healthBarSize;

    void Start()
    {
        healthBar = gameObject.GetComponent<Transform>();
        healthLeft = characterHealth.GetHealthMax;
        healthMax = healthLeft;
        healthBarSize = healthBar.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (characterHealth.GetRemainingHealth > 0)
        {
            healthBar.localScale = new Vector2(characterHealth.GetRemainingHealth / healthMax * healthBarSize, healthBar.localScale.y);
        }
    }
}