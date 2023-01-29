using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



public class PlacementController : MonoBehaviour
{

    [SerializeField] private GameObject placePrefab;

    public GameObject PlacePrefab
    {
        get => placePrefab;
        set => placePrefab = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
