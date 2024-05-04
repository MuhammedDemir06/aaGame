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
    [Header("Animatons")]
    [SerializeField] private Animator menuButtonPressAnim;
    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSound;
    private void Start()
    {
        buttonSound.Pause();
    }
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
        GameManager.IsGameOver = false;
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
        buttonSound.Play();
        StartCoroutine(SceneTransition());
    }
    public void MenuButton(int menuButtonIndex)
    {
       
        switch(menuButtonIndex)
        {
            case 0:// Game Over Screen
                nextSceneName = "Menu";
                buttonSound.Play();
                StartCoroutine(SceneTransition());              
                break;
            case 1: //Game Screen
                nextSceneName = "Menu";
                menuButtonPressAnim.SetTrigger("Press");
                buttonSound.Play();
                StartCoroutine(SceneTransition());
                break;
        }
    }
}
