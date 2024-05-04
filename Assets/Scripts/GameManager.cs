using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //Delegate..
    public delegate void ManagerGame();
    public static ManagerGame OnClick;
    public static ManagerGame DestroyStick;
    public static ManagerGame IncreaseCircleSpeed;
    [Header("Score")]
    public int Score;
    public static int StickScore;
    public int MaxScore;
    [SerializeField]private TextMeshProUGUI stickScoreText;
    [Space(10)]
    [Header("Level System")]
    [SerializeField] private Image nextLevelImage;
    [SerializeField] private float levelPasssTime;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelFinishedText;
    private bool nextLevel;
    public int Level;
    public int MaxLevel;
    [Header("Animation")]
    [SerializeField] private Animator nextLevelAnim;
    public static bool IsGameOver;
    [Header("Sounds")]
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource nextLevelSound;
    private void Start()
    {
        clickSound.Pause();
        nextLevelSound.Pause();
        StickScore = 0;
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        MaxLevel = PlayerPrefs.GetInt("MaxLevel");
    }
    private void Click()
    {
        if (!IsGameOver)
            if (Input.GetMouseButtonDown(0) && !nextLevel)
                if (OnClick != null)
                {
                    OnClick();
                    clickSound.Play();
                    StickScore++;
                    Score++;
                    if (Score>MaxScore)
                    {
                        MaxScore = Score;
                        PlayerPrefs.SetInt("MaxScore", MaxScore);
                    }                  
                    //Next level control 
                    if (StickScore % 10 == 0)
                    {
                        if (IsGameOver == false)
                        {
                            StartCoroutine(LevelPassTime());
                            StartCoroutine(DeleteStickTimer());
                        }                       
                    }
                }
        stickScoreText.text = StickScore.ToString();
    }
    private IEnumerator LevelPassTime()
    {
        nextLevel = true;  
        nextLevelAnim.SetTrigger("Pass");
        nextLevelSound.Play();
        yield return new WaitForSeconds(levelPasssTime);        
        if (IncreaseCircleSpeed != null) //Increase Circle Speed
            IncreaseCircleSpeed();    
        nextLevel = false;       
    }
    private IEnumerator DeleteStickTimer()
    {
        levelFinishedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        levelFinishedText.gameObject.SetActive(false);
        if (DestroyStick != null)//Destroy All Sticks
            DestroyStick();
        Level += 1;
        if(Level>MaxLevel)
        {
            MaxLevel = Level;
            PlayerPrefs.SetInt("MaxLevel",MaxLevel);
        }
        levelText.text = "Level:" + Level.ToString();
    }
    private void Update()
    {
        Click();
    }
    //Developer
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Game/Delete Data")]
#endif
    public static void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        print("Delet All Data");
    }
    //Social Media
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Social Media/Yotube")]
#endif
    public static void YoutubeLink()
    {
        Process.Start("https://www.youtube.com/channel/UCav_F9LX7-lE83KXuuvvcxQ");
    }
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Social Media/LinkedIn")]
#endif
    public static void LýnkedInLink()
    {
        Process.Start("https://www.linkedin.com/in/muhammed-demir-b557b028b/");
    }
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Social Media/GitHub")]
#endif
    public static void GitHubLink()
    {
        Process.Start("https://github.com/MuhammedDemir06");
    }
}
