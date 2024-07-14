using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
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
        
    }
}
