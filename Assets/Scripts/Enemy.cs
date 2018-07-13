using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
	ZOMBIE, 
	ROBOT,
}
public class Enemy : Unit {
    
	public EnemyType enemyType;


	public void SetDefaultLevels(int _health, int _powerLevel)
	{
		//health = _health;
		//powerLevel = _powerLevel;
	}

    public void Hit()
    {
        GameEvents.ReportEnemyHit();
    }
  
    //Subscribes to our game events
    void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
        GameEvents.OnDifficultyChange += OnDifficultyChange;
    }

    //Unsubscribes to our game events
    void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
        GameEvents.OnDifficultyChange -= OnDifficultyChange;
    }

    void OnEnemyHit()
    {
        health -= 10;

    }

    void OnDifficultyChange(Difficulty difficulty)
    {
		switch (difficulty) 
		{
		case Difficulty.EASY:
				health = 100;
			attackPower = 10;
				GetComponent<Renderer> ().material.color = Color.green;
			break;
			case Difficulty.MEDIUM:
				health = 200;
			attackPower = 20;
				GetComponent<Renderer> ().material.color = Color.yellow;
			break;
			case Difficulty.HARD:
				health = 500;
			attackPower = 50;
				GetComponent<Renderer> ().material.color = Color.red;
			break;
			default:
				health = 100;
			attackPower = 10;
				GetComponent<Renderer> ().material.color = Color.green;
			break;
		}
    }

    public void Die()
    {
        GameManager.instance.score += 100;
        GameManager.instance.timer += 10;
    }

}
