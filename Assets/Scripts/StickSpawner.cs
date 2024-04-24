using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSpawner : MonoBehaviour
{
   [SerializeField]private GameObject stick;

   private void OnEnable()
   {
       GameManager.OnClick+=Spawn;
   }
   private void Spawn()
   {
       Instantiate(stick,transform.position,Quaternion.identity);
   }
}
