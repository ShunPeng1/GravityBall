using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGyroMovement : MonoBehaviour
{

    [Header("Rotation Tweaks")] 
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    [SerializeField] private Quaternion gyroRotation ;
    [SerializeField] private Vector3 gyroAngle;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float speed;
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

    Vector3 RotationY(float yDegree, Vector3 vector3) 
    {
        float [,] rotationalMatrix =
        {
            {Mathf.Cos(yDegree), 0, Mathf.Sin(yDegree)},
            {                 0, 1,                  0},
            {-Mathf.Sin(yDegree), 0, Mathf.Cos(yDegree)},
        };
        Vector3 result = new Vector3(
            rotationalMatrix[0,0] * vector3.x + rotationalMatrix[0,1]* vector3.y + rotationalMatrix[0,2] * vector3.z,
            rotationalMatrix[1,0] * vector3.x + rotationalMatrix[1,1]* vector3.y + rotationalMatrix[1,2] * vector3.z,
            rotationalMatrix[2,0] * vector3.x + rotationalMatrix[2,1]* vector3.y + rotationalMatrix[2,2] * vector3.z);
        return result;
    }

    void FixedUpdate()
    {
        gyroRotation = GyroManager.Instance.GetGyroRotation();
        Quaternion swapYZRotation = new Quaternion(gyroRotation.x,gyroRotation.z,gyroRotation.y, - gyroRotation.w);
        gyroRotation = swapYZRotation;
        
        gyroAngle = (swapYZRotation * baseRotation).eulerAngles;
        //_velocity = new Vector3(Mathf.Sin(-gyroAngle.z),0 ,Mathf.Sin(gyroAngle.x)) * speed;
        _velocity = new Vector3(Mathf.Sin(gyroAngle.x * Mathf.Deg2Rad),0 ,Mathf.Sin(gyroAngle.z * Mathf.Deg2Rad)) * speed;

        //_velocity = RotationY(gyroAngle.y, _velocity);
        _rigidbody.velocity = _velocity;
    }
}
