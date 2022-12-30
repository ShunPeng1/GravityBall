using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private void Start()
    {
        HealthInit();
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
    
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int curHealth = 100;

    [SerializeField]
    private Image healthBar;
    private void HealthInit()
    {
        if(healthBar == null) Debug.Log("Missing Health Bar Image");
    }
    public bool TakeDamage(int amount)
    {
        curHealth -= amount;
        healthBarUpdate();   
        
        if (curHealth > 0) return false;
        
        curHealth = 0;
        return true;

    }

    private void healthBarUpdate()
    {
        float faction = (float)curHealth / (float)maxHealth;
        healthBar.fillAmount = faction;
    }

    #endregion

}
