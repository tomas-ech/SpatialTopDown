using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Coins Info")]
    [SerializeField]  GameObject coinPrefab;
    [SerializeField]  int xCoinLimit;
    [SerializeField]  int yCoinLimit;
    [SerializeField]  int spawnCoinRate;

    [Header("Enemy Info")]
    [SerializeField]  int spawnEnemyRate;
    [SerializeField] GameObject[] enemyArray;
    [SerializeField] Transform[] enemySpawnPoint;

    private float timerCoins;
    private float timerEnemies;
    

    

    void Update()
    {
        if (GameManager.Instance.isDead)
        {
            CancelInvoke();
        }
        
        if (!GameManager.Instance.canPlay || GameManager.Instance.isDead) {return;}
        
        timerCoins += Time.deltaTime;
        timerEnemies += Time.deltaTime;


        if (timerCoins > spawnCoinRate)
        {
            timerCoins = 0;
            SpawnCoins();
        }
        if (timerEnemies > spawnEnemyRate)
        {
            timerEnemies = 0;
            SpawnEnemy();
        }
  
    }

    private void SpawnCoins()
    {
        int randomX = Random.Range(-xCoinLimit, xCoinLimit);
        int randomY = Random.Range(-yCoinLimit, yCoinLimit);

        Instantiate(coinPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, enemySpawnPoint.Length);
        int randomEnemy = Random.Range(0, enemyArray.Length);
        
        Instantiate(enemyArray[randomEnemy], enemySpawnPoint[randomSpawnPoint].position, Quaternion.identity);
    }
}
