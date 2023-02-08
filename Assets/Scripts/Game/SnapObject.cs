using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = this.transform.position;
        EnableOrDisableScripts(false);
        StartCoroutine("TriggerDelay");
    }
    IEnumerator TriggerDelay()
    {
        yield return new WaitForSeconds(0.3f);
        EnableOrDisableScripts(true);
    }

    private void EnableOrDisableScripts(bool state)
    {
        this.GetComponent<Collider>().enabled = state;
    }
}
