using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerGyroMovement : MonoBehaviour
{

    [Header("Rotation Tweaks")] 
    [SerializeField] protected Quaternion baseRotation = new Quaternion(0, 0, 0, 0);
    [SerializeField] protected Quaternion gyroRotation ;
    [SerializeField] protected Vector3 gyroAngle;
    
    [SerializeField] protected Vector3 _velocity;
    [SerializeField] protected float speed;
    protected Rigidbody _rigidbody;
    
    private void Start()
    {
        GyroManager.Instance.EnableGyro();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        gyroRotation = GyroManager.Instance.GetGyroRotation();
        Quaternion swapYZRotation = new Quaternion(gyroRotation.x,gyroRotation.z,gyroRotation.y, - gyroRotation.w);
        gyroRotation = swapYZRotation;
        
        gyroAngle = (swapYZRotation * baseRotation).eulerAngles;
        _velocity = new Vector3(Mathf.Sin(gyroAngle.x * Mathf.Deg2Rad),0 ,Mathf.Sin(gyroAngle.z * Mathf.Deg2Rad)) * speed;

        _rigidbody.velocity = _velocity;
    }
}
