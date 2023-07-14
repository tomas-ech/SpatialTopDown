using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public int xLimit;
    public int yLimit;
    public int spawnCoinRate;

    void Start()
    {
        InvokeRepeating("SpawnCoins", 1f, spawnCoinRate);
    }

    void Update()
    {
        
    }

    private void SpawnCoins()
    {
        int randomX = Random.Range(-xLimit, xLimit);
        int randomY = Random.Range(-yLimit, yLimit);

        Instantiate(coinPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}
