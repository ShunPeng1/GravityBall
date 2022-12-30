using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class WorldTasksManager : MonoBehaviour
{
    #region Instance

    private static WorldTasksManager _instance;

    public static WorldTasksManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType < WorldTasksManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned WorldTasksManager", typeof(WorldTasksManager)).GetComponent <WorldTasksManager>();
                }
            }

            return _instance;
        }
        set
        {
            _instance = value;    
        }
    }
    #endregion


    private void Start()
    {
        CoinsCount();
    }
    
    [SerializeField] private Object[] coins;
    private void CoinsCount()
    {
         coins = Resources.FindObjectsOfTypeAll(typeof(CoinCollectible));
    }

    public int GetTotalCoins()
    {
        return coins.Length - 1;
    }
}
