using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGyroMovement : PlayerGyroMovement
{
    [Header("Damage")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float delayLosingTime = 1f;
    [SerializeField] private float bounceForce;
    
    private void OnCollisionEnter(Collision collision)
    {
        if ( !collision.gameObject.CompareTag("Player") ) return;
        
        if ( collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage) )
        {
            Invoke(nameof(DelayLosing), delayLosingTime);
        }
        else
        {
            // Bounces the player by a particular force

        }
    }
    
    private void DelayLosing()
    {
        UiManager.Instance.Losing();
    }

}
