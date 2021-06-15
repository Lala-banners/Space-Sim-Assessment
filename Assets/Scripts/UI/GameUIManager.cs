using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class will be called when the player has won the game by destroying the enemy spaceship
/// </summary>
public class GameUIManager : MonoBehaviour
{
    [Header("Win Menu UI")] 
    public GameObject winMenu;
    public Button returnMainMenu;
    public Button restartButton;
    public Button quitButton;
    public TMP_Text framerateText;
    
    public static GameUIManager instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        winMenu.SetActive(false);
    }
    
    public void LimitFrameRate() {
        var frameRate = Application.targetFrameRate = 300;
        framerateText.text = "Frame Rate: " + frameRate;
    }

    private void Update() {

        LimitFrameRate();
        
        returnMainMenu.onClick.AddListener(() => {
            ReturnToMainMenu();
        });
        
        restartButton.onClick.AddListener(() => {
            Restart();
        });
        
        quitButton.onClick.AddListener(() => {
            QuitGame();
        });
    }

    
    
    public void WinGame() {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public void Restart() {
        Time.timeScale = 1;
        winMenu.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}