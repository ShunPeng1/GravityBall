using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{

    [Header("Rotation Tweaks")] 
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    [SerializeField] private Quaternion gyroRotation ;
    [SerializeField] private float rotationSpeed;
    [Header("Rigidbody")] private Rigidbody _rigidbody;
    
    private void Start()
    {
        GyroManager.Instance.EnableGyro();
        _rigidbody = GetComponent<Rigidbody>();
    }

    /*
    void Update()
    {
        gyroRotation = GyroManager.Instance.GetGyroRotation();
        Quaternion swapYZRotation = new Quaternion(gyroRotation.x,gyroRotation.z,gyroRotation.y, - gyroRotation.w);
        //transform.localRotation = swapYZRotation * baseRotation;

        _rigidbody.angularVelocity = (swapYZRotation*baseRotation ).eulerAngles.normalized * rotationSpeed;
    }
*/
    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        gyroRotation = GyroManager.Instance.GetGyroRotation();
        Quaternion swapYZRotation = new Quaternion(gyroRotation.x,gyroRotation.z,gyroRotation.y, - gyroRotation.w);
        
        _rigidbody.rotation = (swapYZRotation * baseRotation).normalized;

        //Quaternion rotationDifference = (Quaternion.Inverse( gameObject.transform.rotation ) * swapYZRotation)  ;
        
        //_rigidbody.MoveRotation(swapYZRotation.normalized);
        //Debug.Log("Rotation Difference "+ rotationDifference);
        //_rigidbody.angularVelocity = rotationDifference.eulerAngles * (Time.fixedDeltaTime * Mathf.Deg2Rad);
        //_rigidbody.angularVelocity = Vector3.up * (45f * Mathf.Deg2Rad);

    }
}
