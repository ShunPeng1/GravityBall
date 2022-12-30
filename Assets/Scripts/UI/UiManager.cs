using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class UiManager : MonoBehaviour
{
    #region Instance

    private static UiManager _instance;

    public static UiManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType < UiManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned UiManager", typeof(UiManager)).GetComponent <UiManager>();
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

    #region Score
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private string textScoreFormat = "Score: ";
    public void UpdateScore(int score)
    {
        textScore.text = textScoreFormat + score.ToString();
    }
    
    #endregion
    
    #region Pause
    [Header("Pause")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button pauseButton;

    private void StallingGame(){
        Time.timeScale = 0;
    }
    
    private void ResumingGame(){
        Time.timeScale = 1;
    }

    public void Pausing()
    {
        StallingGame();
        pauseMenu.SetActive(true);
        pauseButton.interactable = false;
    }
    
    public void Unpausing()
    {
        ResumingGame();
        pauseMenu.SetActive(false);
        pauseButton.interactable = true;
    }

    #endregion

    #region WinGame
    [Header("Win Game")]
    [SerializeField] private GameObject winGameMenu;

    public void Winning()
    {
        winGameMenu.SetActive(true);
        StallingGame();
    }
    
    #endregion
    
}
