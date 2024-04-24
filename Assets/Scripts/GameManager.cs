using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public delegate void ManagerGame();
    public static ManagerGame OnClick;
    public static int StickScore;
    [SerializeField]private TextMeshProUGUI stickScoreText;

    private void Start()
    {
        StickScore=0;
    }
    private void Click()
    {
        if(Input.GetMouseButtonDown(0))
         if(OnClick!=null)
         {
            OnClick();
            StickScore++;
         }           
         stickScoreText.text=StickScore.ToString();
    }
    private void Update()
    {
        Click();
    }
}
