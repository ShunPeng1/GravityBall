using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private float delayLosingTime = 1f;

    
    private void OnCollisionEnter(Collision collision)
    {
        if ( !collision.gameObject.CompareTag("Player") ) return;
        
        if ( collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage) )
        {
            Invoke(nameof(DelayLosing), delayLosingTime);
        }
    }
    
    private void DelayLosing()
    {
        UiManager.Instance.Winning();
    }
    
}
