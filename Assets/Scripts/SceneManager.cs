using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    #region Instance

    private static SceneManager _instance;

    public static SceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType < SceneManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned SceneManager", typeof(SceneManager)).GetComponent <SceneManager>();
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
    
    
    private void ResumingGame(){
        Time.timeScale = 1;
    }
    
    public void RestartScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        ResumingGame();
    }

    public void GetNextScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
        ResumingGame();
    }

    public void GetHomeScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        ResumingGame();
    }
}