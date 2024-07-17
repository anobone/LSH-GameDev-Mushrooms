using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthMax;
    float healthLeft;
    private void Awake()
    {
        healthLeft = healthMax;
    }

    public float GetHealthMax
    {
        get { return healthMax; }
    }
    public float GetRemainingHealth
    {
        get { return healthLeft; }
    }

    public void HealthDown(float damage)
    {
        if (healthLeft == 0)
        {
            return;
        }

        healthLeft -= damage;

        if (healthLeft < 0)
        {
            healthLeft = 0;
        }
        /*Debug.Log(healthLeft);*/
    }

    public void HealthUp(float heal)
    {
        if (healthLeft == healthMax) 
        {
            return;
        }

        healthLeft += heal;

        if (healthLeft > healthMax)
        {
            healthLeft = healthMax;
        }
    }

    public bool IsDead()
    {
        if (healthLeft > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    
}
