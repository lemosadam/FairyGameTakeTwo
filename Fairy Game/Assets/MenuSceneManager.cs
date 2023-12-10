using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public string gameSceneName = "CastleLevel";
    public string creditsSceneName = "CreditsScene";
    public string menuSceneName = "MainMenu";
    public string letterSceneName = "FinalLetterScene";

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(creditsSceneName);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
    public void LoadLetterScene()
    {
        SceneManager.LoadScene(letterSceneName);
    }
}
