using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LedgeGrabChecker"))
        {
            Player player = other.transform.parent.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("Could not get Player in Ledge.");
            }
            else
            {
                player.GrabLedge();
            }
        }
    }
}
