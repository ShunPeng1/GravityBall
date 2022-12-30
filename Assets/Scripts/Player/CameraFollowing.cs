using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float height;
    
    void Start()
    {
        gameObject.transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerTransform.position + Vector3.up*height;   
    }
}
