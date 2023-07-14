using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_Game : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Image dashMeter;
    [SerializeField] TextMeshProUGUI scoreText;
    private float remainingCd;
    


    void Start()
    {
        InvokeRepeating("UpdateScore", 0.1f, 0.2f);
    }

    void Update()
    {
        if (playerMovement.isDashing)
        {
            remainingCd = 0;
        }
        dashMeter.fillAmount = remainingCd / playerMovement.dashCooldown;

        remainingCd += Time.deltaTime;
    }

    private void UpdateScore()
    {
        scoreText.text = GameManager.Instance.score.ToString("F0");
    }
}
