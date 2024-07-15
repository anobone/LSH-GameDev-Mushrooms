using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour
{
    [SerializeField] Sprite youWin;
    [SerializeField] Sprite youLose;
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject conditions;
    public int enemiescount;
    void Start()
    {
        enemiescount = GameObject.FindGameObjectsWithTag("Enemy").ToList().Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiescount == 0)
        {
            conditions.SetActive(true);
            conditions.GetComponent<Image>().sprite = youWin;
        }
        if (playerHealth.GetRemainingHealth <= 0)
        {
            conditions.SetActive(true);
            conditions.GetComponent<Image>().sprite = youLose;
        }
    }

    public void Check()
    {
        enemiescount--;
    }
}
