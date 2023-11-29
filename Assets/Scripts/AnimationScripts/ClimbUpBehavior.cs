using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpBehavior : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var player = animator.gameObject.transform.parent.GetComponent<Player>();

        if (player != null)
        {
            player.ClimbUpComplete();
        }
        else
        {
            Debug.LogError("Could not get player in ClimbUpBehavior.");
        }

    }
}
