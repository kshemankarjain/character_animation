using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlling_jump : MonoBehaviour
{
    Animator animator;
    int isJumpingHash;
    float Velocity = 0;
 
    public float accelaration = 2.0f;
    public float deaccelaration = 2.0f;
    public float maxRunVelocity = 2.0f;
    public float maxWalkVelocity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isJumpingHash = Animator.StringToHash("IsJumping");

    }

    // Update is called once per frame
    void Update()
    {
       bool spacebarpressed = Input.GetKey("space");

        if (spacebarpressed && Velocity < accelaration)
        {
            Velocity += Time.deltaTime * accelaration;
        }else
        {
            spacebarpressed = false;
        }
        if (!spacebarpressed && Velocity > 0.0f)
        {
            Velocity -= Time.deltaTime * deaccelaration;
        }
        animator.SetFloat("Velocity", Velocity);
  
    }
}
