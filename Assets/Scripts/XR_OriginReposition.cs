using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XR_OriginReposition : MonoBehaviour
{
    public GameObject XR_Origin1;
    public GameObject XR_Origin2;
    // Start is called before the first frame update
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            XR_Origin1.gameObject.SetActive(false);
            XR_Origin2.gameObject.SetActive(true);
        }
    }
}
