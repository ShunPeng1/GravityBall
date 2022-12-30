using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{

    [SerializeField] private Collider _collider;
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    protected abstract void OnTriggerEnter(Collider other);
}
