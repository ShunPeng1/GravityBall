using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FinishedZone : MonoBehaviour
{
    [SerializeField] private float delayWinningTime = 0.5f;
    protected abstract bool CheckWinGame(Collider other);
    
    
    private void OnTriggerEnter(Collider other)
    {
        if ( !other.CompareTag("Player") ) return;

        
        if (CheckWinGame(other))
        {
              Invoke(nameof(DelayWinning), delayWinningTime);
        }
        
    }
    private void DelayWinning()
    {
        UiManager.Instance.Winning();
    }
}
