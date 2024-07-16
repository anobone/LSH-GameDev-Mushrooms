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
    bool setOnce = true;
    public int enemiescount;
    void Start()
    {
        enemiescount = GameObject.FindGameObjectsWithTag("Enemy").ToList().Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (setOnce)
        {
            if (enemiescount == 0)
            {
                conditions.SetActive(true);
                conditions.GetComponent<Image>().sprite = youWin;
                SetOnce();
            }
            if (playerHealth.GetRemainingHealth <= 0)
            {
                conditions.SetActive(true);
                conditions.GetComponent<Image>().sprite = youLose;
                SetOnce();
            }
        }
    }

    private void SetOnce()
    {
        setOnce = false;
    }
    public void Check()
    {
        enemiescount--;
    }
}
