using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public delegate void ManagerGame();
    public static ManagerGame OnClick;
    public static ManagerGame DestroyStick;
    public static ManagerGame IncreaseCircleSpeed;

    public static int StickScore;
    [SerializeField]private TextMeshProUGUI stickScoreText;
    [Space(10)]
    [Header("Level System")]
    [SerializeField] private Image nextLevelImage;
    [SerializeField] private float levelPasssTime;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelFinishedText;
    private bool nextLevel;
    public int Level;
    [SerializeField] private Animator nextLevelAnim;
    public static bool IsGameOver;
    private void Start()
    {
        StickScore = 0;
        Level = 0;
        levelText.text = "Level:1";
    }
    private void Click()
    {
        if (!IsGameOver)
            if (Input.GetMouseButtonDown(0) && !nextLevel)
                if (OnClick != null)
                {
                    OnClick();
                    StickScore++;
                    //Next level control 
                    if (StickScore % 10 == 0&& IsGameOver==false)
                    {
                        StartCoroutine(LevelPassTime());
                        StartCoroutine(DeleteStickTimer());
                    }
                }
        stickScoreText.text = StickScore.ToString();
    }
    private IEnumerator LevelPassTime()
    {
        nextLevel = true;  
        nextLevelAnim.SetTrigger("Pass");       
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
        levelText.text = "Level:" + Level.ToString();
    }
    private void Update()
    {
        Click();
    }
}
