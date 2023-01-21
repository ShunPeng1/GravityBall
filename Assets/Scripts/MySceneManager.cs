using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    #region Instance

    private static MySceneManager _instance;

    public static MySceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType < MySceneManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned SceneManager", typeof(MySceneManager)).GetComponent <MySceneManager>();
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
    
    
    public void RestartScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GetNextScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
    }

    public void GetHomeScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
