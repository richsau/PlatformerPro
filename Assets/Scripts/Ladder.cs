using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LadderChecker"))
        {
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

}
