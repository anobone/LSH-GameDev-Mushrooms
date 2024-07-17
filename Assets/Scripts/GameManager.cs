using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Sprite youWin;
    [SerializeField] Sprite youLose;
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject conditions;
    bool setOnce = true;
    public int enemiescount;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Какая-то скотина пытается бахнуть второй геймменеджер!");
        }
    }

    void Start()
    {
        enemiescount = GameObject.FindGameObjectsWithTag("Enemy").ToList().Count;
    }

    // Update is called once per frame

    private void SetOnce()
    {
        setOnce = false;
    }
    public void DecrementEnemies()
    {
        enemiescount--;
        if (enemiescount <= 0)
        {
            conditions.SetActive(true);
            conditions.GetComponent<Image>().sprite = youWin;
            SetOnce();
        }
    }

    public void ShowLoseScreen()
    {
        if (playerHealth.GetRemainingHealth <= 0)
        {
            conditions.SetActive(true);
            conditions.GetComponent<Image>().sprite = youLose;
            SetOnce();
        }
    }
}
