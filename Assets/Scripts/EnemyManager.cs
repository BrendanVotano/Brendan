using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager> 
{
	public Enemy[] enemy;
	public float speed; //TODO: change to be based on enemy weight
    public int enemyCount;
    public int randomEnemy;

	// Use this for initialization
	void Start () 
	{
        enemy = GameObject.FindObjectsOfType<Enemy>();
        enemyCount = enemy.Length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
            randomEnemy = RandomEnemy();
            enemy[randomEnemy].Hit();
		}

		//Our movement section
		float h = Input.GetAxis ("Horizontal");	
		float v = Input.GetAxis ("Vertical");

		enemy[randomEnemy].transform.Translate (h * speed, 0, v * speed);
	}

	void Randomize()
	{
		float rndX = Random.Range (-10, 10);
		float rndZ = Random.Range (-10, 10);
		enemy[randomEnemy].transform.position = new Vector3 (rndX, 0, rndZ);
	}

    int RandomEnemy()
    {
        int rnd = Random.Range(0, enemy.Length);
        return rnd;
    }

    //Subscribes to our game events
    void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
    }

    //Unsubscribes to our game events
    void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
    }

    void OnEnemyHit()
    {
        Randomize();
    }
}