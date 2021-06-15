using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class will manage the main menu stats, and scene loading into the game scene.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button startGame;
    public Button options;
    public Button quitGame;

    [Header("Menus")] 
    public GameObject mainMenu;
    public GameObject optionsMenu;
    
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        startGame.onClick.AddListener(() => StartGame());
        options.onClick.AddListener(() => OptionsMenu());
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

    public void OptionsMenu() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
