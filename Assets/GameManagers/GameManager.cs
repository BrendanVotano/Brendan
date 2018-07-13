using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD,
}

public enum GameState
{
	TITLE,
	INGAME,
	PAUSE,
	GAMEOVER
}

public class GameManager : Singleton<GameManager>
{
    public int score = 0;
    public int lives;
    public float timer = 100;

	public Difficulty difficulty;
	/*public Difficulty difficulty{
		get{
			return _difficulty;
		}
		set{
			_difficulty = value;
			GameEvents.ReportDifficultyChange (value);
		}
	}*/
	/*[SerializeField]
	private Difficulty _difficulty;*/

	public GameState gameState;
    
    void Start()
    {
		difficulty = Difficulty.MEDIUM;
		GameEvents.ReportDifficultyChange (difficulty);
		gameState = GameState.TITLE;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            LoadNewScene();

		if (Input.GetKeyDown(KeyCode.Return))
            CycleDifficulty();
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("SceneTwo");
    }

    //TODO next week make better with buttons and Switch Statements
    void CycleDifficulty()
    {
		switch (difficulty) 
		{
			case Difficulty.EASY:
				difficulty = Difficulty.MEDIUM;
				break;
			case Difficulty.MEDIUM:
				difficulty = Difficulty.HARD;
				break;
			case Difficulty.HARD:
				difficulty = Difficulty.EASY;
				break;
			default:
				difficulty = Difficulty.EASY;
				break;
		}

        GameEvents.ReportDifficultyChange(difficulty);

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
        score += 10;
        timer += 1;
    }

    void OnDifficultyChange(Difficulty diff)
    {

    }


    #region Old
    /*public static GameManager instance;

    public int score = 0;
    public int lives;
    public float timer = 100;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //Ensures we dont destroy our game manager object across scenes
        DontDestroyOnLoad(gameObject);
    */

    #endregion
}
