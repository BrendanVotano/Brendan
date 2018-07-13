using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> {

    public float volume;
    public static bool mute;

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
        Debug.Log("TODO ENEMY HIT SOUND");
    }
}
