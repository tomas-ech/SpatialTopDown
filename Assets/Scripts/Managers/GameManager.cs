using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public bool isDead = false;

    [Header("Score Info")]
    public int coins;
    public int enemies;
    public int score;

    public GameObject[] enemyPaths;
    public float enemySpeed = 1.0f;
    private float dificultyTimer = 0;

    [HideInInspector] public bool canPlay = false;

    public GameObject dead_UI;
    public GameObject game_UI;


    private void Awake()
    {
      
        Instance = this;	

        canPlay = false;
        isDead = false;
    }

    void Update()
    {
        if (isDead)
        {
            dead_UI.SetActive(true);
            game_UI.SetActive(false);
            Save();
            Cursor.visible = true;
        }

        dificultyTimer += Time.deltaTime;

        if (dificultyTimer > 35)
        {
            dificultyTimer = 0;
            enemySpeed += 0.15f;
        }

        score = (coins * 5) + (enemies * 8);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Coins", coins);

        PlayerPrefs.SetInt("Enemy", enemies);

        PlayerPrefs.SetInt("LastScore", score);

        float lastScore = PlayerPrefs.GetFloat("LastScore", score);

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
