using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startGame;
    public Button quitGame;
    
    void Start()
    {
        startGame.onClick.AddListener(() => StartGame());
        quitGame.onClick.AddListener(() => QuitGame());
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
