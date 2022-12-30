using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private void Start()
    {
        
    }

    #region Score
    
    private int _score = 0;
    public int GetScore()
    {
        return _score;
    }
    
    public void AddScore(int addingScore)
    {
        _score += addingScore;
        UiManager.Instance.UpdateScore(_score);
    }

    #endregion

    #region Health
    [Header("Health")]
    [SerializeField] private int health = 100;

    public bool TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            return true;
        }

        return false;
    }


    #endregion

}
