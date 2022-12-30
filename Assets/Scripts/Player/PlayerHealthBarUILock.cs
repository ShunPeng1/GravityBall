using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBarUILock : MonoBehaviour
{
    [SerializeField] private Quaternion lockedRotation;
    [SerializeField] private Vector3 lockedPosition;
    [SerializeField] private Vector3 lockedParentPosition;
    private Vector3 _deltaPosition;
    private void Start()
    {
        lockedRotation = transform.rotation;
        lockedPosition = transform.position;
        lockedParentPosition = transform.parent.position;
        _deltaPosition = lockedPosition - lockedParentPosition;
    }

    void Update()
    {
        transform.rotation = lockedRotation;
        transform.position = transform.parent.position + _deltaPosition;
    }
}
