using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsVertifyFinishedZone : FinishedZone
{
    [SerializeField] private int numberOfCoinsRequire = 1;
    [SerializeField] private bool allCoins = true;

    private bool _isInit = false;
    private void Init()
    {
        int totalCoins = WorldTasksManager.Instance.GetTotalCoins();
        if (allCoins || totalCoins < numberOfCoinsRequire)
        {
            numberOfCoinsRequire = totalCoins;
        }

        _isInit = true;
    }

    protected override bool CheckWinGame(Collider other)
    {
        if (!_isInit) Init();
        
        if (other.GetComponent<PlayerStats>().GetScore() >= numberOfCoinsRequire)
        {
            //Debug.Log("Success Zone");
            return true;
        }
        
        //Debug.Log("Not enough");
        return false;
        
    }
}
