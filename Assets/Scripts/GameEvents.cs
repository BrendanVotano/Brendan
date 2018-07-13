using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnEnemyHit = null;   //The event that fires to all scripts
    public static event Action OnPlayerHit = null;  //The event that fires to all scripts

    public static event Action<Difficulty> OnDifficultyChange = null;

    //Events
    public static void ReportEnemyHit()
    {
        //Debug.Log("On Enemy Hit");
        if (OnEnemyHit != null)
            OnEnemyHit();
    }

    public static void ReportPlayerHit()
    {
        //Debug.Log("On Player Hit");
        if (OnPlayerHit != null)
            OnPlayerHit();
    }

    public static void ReportDifficultyChange(Difficulty difficulty)
    {
        //Debug.Log("Difficulty Changed to " + diff);
        if (OnDifficultyChange != null)
            OnDifficultyChange(difficulty);
    }
    



















    /*public static void ReportGameOver()
    {
        // Debug.Log (">>> EVENT: ReportGameOver");
        if (OnGameOver != null)
            OnGameOver();
    }

    public static void ReportPowerUpLevel(float powerUpLevel)
    {
        // Debug.Log (">>> EVENT: ReportPowerLevel(("+powerUpLevel+")");
        if (OnPowerUpLevel != null)
            OnPowerUpLevel(powerUpLevel);
    }*/
}
