using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RollingBehaviourScript : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var player = animator.gameObject.transform.parent.GetComponent<Player>();

        Debug.Log("Rolling State Exit");
        if (player != null)
        {
            player.RollingComplete();
        }
        else
        {
            Debug.LogError("Could not get player in RollingBehavior.");
        }
    }
}
