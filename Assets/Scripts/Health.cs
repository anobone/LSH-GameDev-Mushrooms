using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthMax;
    [SerializeField] float healthLeft;


    public float RemainingHealth
    {
        get
        {
            return healthLeft;
        }
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
        //Debug.Log(healthLeft);
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
}
