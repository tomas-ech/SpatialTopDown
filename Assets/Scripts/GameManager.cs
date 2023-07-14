using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    //public 

    [Header("Score Info")]
    public int coins;
    public int enemies;
    public int score;


    private void Awake()
    {
        if(Instance != null && Instance != this)
		{
			Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);	
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        score = (coins * 5) + (enemies * 8);
    }

}
