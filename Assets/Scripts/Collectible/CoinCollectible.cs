using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : Collectible
{
    // Start is called before the first frame update
    

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().AddScore(1);
            Destroy(gameObject);   
        }

    }

    
}
