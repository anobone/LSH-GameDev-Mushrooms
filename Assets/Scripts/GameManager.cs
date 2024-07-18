using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Sprite youWin;
    [SerializeField] Sprite youLose;
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject conditions;
    [SerializeField] GameObject blackout;
    [SerializeField] GameObject continueGameButton;
    bool isPaused = false;
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

    public void DecrementEnemies()
    {
        enemiescount--;
        if (enemiescount <= 0)
        {
            conditions.SetActive(true);
            conditions.GetComponent<Image>().sprite = youWin;
        }
    }

    public void ShowLoseScreen()
    {
        if (playerHealth.GetRemainingHealth <= 0)
        {
            conditions.SetActive(true);
            conditions.GetComponent<Image>().sprite = youLose;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            continueGameButton.SetActive(true);
            blackout.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            continueGameButton.SetActive(false);
            blackout.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
