using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] Sprite youWin;
    [SerializeField] Sprite youLose;
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject conditions;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        foreach (GameObject go in enemies) 
        { 
            Debug.Log(go.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies == null)
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
}
