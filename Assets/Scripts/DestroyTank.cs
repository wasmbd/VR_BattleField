using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DestroyTank : MonoBehaviour
{
   public GameObject TankPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            Destroy(TankPrefab); 
        }
    }
}
