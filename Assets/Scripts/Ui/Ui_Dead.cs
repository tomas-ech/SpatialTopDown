using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui_Dead : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void Update()
    {
        enemyText.text = "Enemies Defeated: " + PlayerPrefs.GetInt("Enemy").ToString();
        coinsText.text = "Coins Recolected: " + PlayerPrefs.GetInt("Coins").ToString();
        scoreText.text = "Last Score: " + PlayerPrefs.GetInt("LastScore").ToString();
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
