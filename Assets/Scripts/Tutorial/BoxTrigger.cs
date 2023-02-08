using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public delegate void boxTrigger();
    public static event boxTrigger OnBoxTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grabable")
        {
            Destroy(other.gameObject);
            OnBoxTrigger();
        }              
    }
}
