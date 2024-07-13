using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    RectTransform healthBar;
    [SerializeField] float healthMax;
    float healthLeft;
    [SerializeField] float speed;
    float healthBarSize;

    void Start()
    {
        healthBar = gameObject.GetComponent<RectTransform>();
        healthLeft = healthMax;
        healthBarSize = healthBar.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthLeft > 0)
        {
            healthLeft -= Time.deltaTime*speed;
            healthBar.sizeDelta = new Vector2(healthLeft / healthMax * healthBarSize, healthBar.sizeDelta.y);
        }
        if (healthLeft < 0)
        {
            healthLeft = 0;
        }
        if (healthLeft > healthMax) 
        { 
            healthLeft = healthMax;
        }
    }

    public void HealthDown(float healthPercent)
    {
        healthLeft -= healthMax * (healthPercent / 100);
        Debug.Log(healthLeft);
    }

    public void HealthUp(float healthPercent) 
    {
        if (healthLeft > 0)
        {
            healthLeft += healthMax * (healthPercent/100);
        }
    }

    public void TryAgainScreen()
    {

    }
}
