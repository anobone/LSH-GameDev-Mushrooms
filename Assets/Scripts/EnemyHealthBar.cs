using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    RectTransform healthBar;
    [SerializeField] Health characterHealth;
    float healthMax;
    float healthLeft;
    [SerializeField] float speed;
    float healthBarSize;

    void Start()
    {
        healthBar = gameObject.GetComponent<RectTransform>();
        healthLeft = characterHealth.GetHealthMax;
        healthMax = healthLeft;
        healthBarSize = healthBar.sizeDelta.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (characterHealth.GetRemainingHealth > 0)
        {
            healthBar.sizeDelta = new Vector2(characterHealth.GetRemainingHealth / healthMax * healthBarSize, healthBar.sizeDelta.y);
        }
    }
}