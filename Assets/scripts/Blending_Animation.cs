using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blending_Animation : MonoBehaviour
{
    Animator animator;
      float velocity = 0.0f;
    public float accelaration= 0.2f;
    public float deaccelaration = 0.5f;
    int velocityhash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityhash = Animator.StringToHash("velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardpress = Input.GetKey("w");
       // bool runpress = Input.GetKey("left shift");

        if(forwardpress && velocity< 1.0f)
        {
            velocity += Time.deltaTime * accelaration;
        }
        if(!forwardpress && velocity >0.0f)
        {
            velocity -= Time.deltaTime * deaccelaration;
        }
        if(!forwardpress && velocity < 0.0f)
        {
            velocity = 0.0f;
        }
            animator.SetFloat(velocityhash, velocity);


    }
}
