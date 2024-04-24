using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField]private float turnSpeed;

    private void CircleTurn()
    {
        transform.Rotate(Vector3.forward*turnSpeed*Time.deltaTime);
    }
    private void Update()
    {
        CircleTurn();
    }
}
