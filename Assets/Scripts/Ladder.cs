using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    private Vector3 _handPos;
    [SerializeField]
    private Vector3 _standPos;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LadderChecker"))
        {
            Debug.Log("Trigger Checker");
            Player player = other.transform.parent.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("Could not get Player in Ladder.");
            }
            else
            {
                player.GrabLadder();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("LedgeGrabChecker"))
        {
            Debug.Log("LedgeGrabChecker");
            Player player = other.transform.parent.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("Could not get Player in Ladder.");
            }
            else
            {
                player.ClimbLedge();
            }
        }
    }

    public Vector3 GetStandPos()
    {
        return _standPos;
    }
}
