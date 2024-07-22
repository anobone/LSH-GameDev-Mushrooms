using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadgehogShito : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.Play("hedgerun");
        }
    }
}
