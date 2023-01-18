using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance

    private static GyroManager _instance;

    public static GyroManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType < GyroManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent <GyroManager>();
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

    [Header("Logic")]
    private Gyroscope _gyro;
    private Quaternion _rotation;
    private bool gyroActive;

    public void EnableGyro()
    {
        if (gyroActive)
        {
            return;
        }

        if (SystemInfo.supportsGyroscope)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;
            gyroActive = _gyro.enabled;

        }
        else
        {
            Debug.Log("Gyro is not support on this device!");
        }
    }

    public void Update()
    {
        if (gyroActive)
        {
            _rotation = _gyro.attitude;
            
            //DebugTest();
            //Debug.Log(_rotation);
        }
    }

    public Quaternion GetGyroRotation()
    {
        return _rotation;
    }

    #region Debug

    [SerializeField] private TextMeshProUGUI _debugText;

    public void DebugTest()
    {
        if (_debugText != null) _debugText.text = _gyro.userAcceleration.ToString();
    }

    #endregion


}
