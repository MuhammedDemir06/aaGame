using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuManager : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator playButtonAnim;
    [SerializeField] private Animator exitButtonAnim;
    private int buttonIndex;
    [SerializeField] private SceneTransition sceneTransition;
    [Header("Texts")]
    [SerializeField] private string gameName;
    [SerializeField] private TextMeshProUGUI gameNameText;
    [SerializeField] private float waitTime;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI maxLevelText;
    private int maxLevel;
    private int maxScore;
    [Header("Objects")]
    [SerializeField] private GameObject circle;
    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSound;
    private void Start()
    {
        gameNameText.text = "";
        StartCoroutine(GameNameAnimTimer());
        ScoreSystem();
    }
    private void ScoreSystem()
    {
        maxLevel = PlayerPrefs.GetInt("MaxLevel");
        maxScore = PlayerPrefs.GetInt("MaxScore");

        maxScoreText.text = "Max Score:" + maxScore.ToString();
        maxLevelText.text = "Max Level:" + maxLevel.ToString();
    }
    private void Update()
    {
        circle.transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
    }
    private IEnumerator GameNameAnimTimer()
    {
        foreach(char gameNameChar in gameName.ToCharArray())
        {
            gameNameText.text += gameNameChar;
            yield return new WaitForSeconds(waitTime);
        }      
    }
    private IEnumerator SceneTransitionTimer()
    {
        sceneTransition.gameObject.SetActive(true);
        sceneTransition.NextScene();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }
    //Buttons
    private IEnumerator ButtonTimer()
    {
        yield return new WaitForSeconds(0.333f);
        switch (buttonIndex)
        {
            case 0:
                //Load Game Scene
                StartCoroutine(SceneTransitionTimer());
                break;
            case 1:
                //Exit Game
                Application.Quit();
                break;
        }
    }
    public void PlayButton()
    {
        buttonIndex = 0;
        playButtonAnim.SetTrigger("Press");
        buttonSound.Play();
        StartCoroutine(ButtonTimer());       
    }
    public void ExitButton()
    {
        buttonIndex = 1;
        exitButtonAnim.SetTrigger("Press");
        buttonSound.Play();
        StartCoroutine(ButtonTimer());      
    }
}
