using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class StickController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private bool isHit;
    private int score;
    [SerializeField] private TextMeshPro scoreText;
    private void Start()
    {
        score = GameManager.StickScore;
        scoreText.text = score.ToString();
    }
    private void StickMove()
    {
        if (!isHit)
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
    private void Update()
    {
        StickMove();
    }
    //Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            isHit = true;
            transform.SetParent(collision.transform);
        }
        if (collision.gameObject.tag == "Stick")
        {
            Debug.LogWarning("Game Over");
        }
    }
}
