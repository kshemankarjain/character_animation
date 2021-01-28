using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    int isWalkingHash;
    int isRunnignHash;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunnignHash = Animator.StringToHash("IsRunning");

    }

    // Update is called once per frame
    void Update()
    {
        bool isalreadyrunning = animator.GetBool(isRunnignHash);
        bool ForwardPress = (Input.GetKey("w"));
        bool runpressed = (Input.GetKey("left shift"));
        bool IsWalking = animator.GetBool(isWalkingHash);


        if (!IsWalking &&  ForwardPress)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (IsWalking && !ForwardPress)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (!isalreadyrunning && (ForwardPress && runpressed))
        {
            animator.SetBool(isRunnignHash, true);
        }
        if (isalreadyrunning && (!ForwardPress || !runpressed))
        {
            animator.SetBool(isRunnignHash, false);
        }
    }
}
