using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Coins Info")]
    public GameObject coinPrefab;
    public int xCoinLimit;
    public int yCoinLimit;
    public int spawnCoinRate;

    [Header("Enemy Info")]
    public GameObject[] enemyArray;

    void Start()
    {
        InvokeRepeating("SpawnCoins", 1f, spawnCoinRate);
    }

    void Update()
    {
        
    }

    private void SpawnCoins()
    {
        int randomX = Random.Range(-xCoinLimit, xCoinLimit);
        int randomY = Random.Range(-yCoinLimit, yCoinLimit);

        Instantiate(coinPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}
