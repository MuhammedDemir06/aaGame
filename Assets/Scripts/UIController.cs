using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;
    [Header("UI GameObjects")]
    [SerializeField] private GameObject gameOverScreen;
    private string nextSceneName;
    private void GameOverController()
    {
        if(GameManager.IsGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    private IEnumerator SceneTransition()
    {
        sceneTransition.gameObject.SetActive(true);
        sceneTransition.NextScene();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }
    private void Update()
    {
        GameOverController();
    }
    //Buttons
    public void RestartButton()
    {
        GameManager.IsGameOver = false;
        nextSceneName = "Game";
        StartCoroutine(SceneTransition());
    }
    public void MenuButton()
    {
        nextSceneName = "Menu";
        StartCoroutine(SceneTransition());
    }
}
