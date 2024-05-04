using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    private void OnEnable()
    {
        GameManager.DestroyStick += DeleteGameObjectChilds;
        GameManager.IncreaseCircleSpeed += TurnSpeedControl;
    }
    private void OnDisable()
    {
        GameManager.DestroyStick -= DeleteGameObjectChilds;
        GameManager.IncreaseCircleSpeed -= TurnSpeedControl;
    }
    private void DeleteGameObjectChilds()
    {
        GameObject[] children = new GameObject[transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject child in children)
        {
            Destroy(child);
        }
    }
    private void CircleTurn()
    {
        transform.Rotate(Vector3.forward*turnSpeed*Time.deltaTime);
    }
    private void TurnSpeedControl()
    {
        turnSpeed += 5f;
    }
    private void Update()
    {
        CircleTurn();
    }
}
