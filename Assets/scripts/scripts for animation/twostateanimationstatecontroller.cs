using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twostateanimationstatecontroller : MonoBehaviour
{ 
   
    Animator animator;
    
    float VelocityX = 0;
    float VelocityZ = 0;

    public float accelaration = 2.0f;
    public float deceleration = 2.0f;
    public float maxRunVelocity = 2.0f;
    public float maxWalkVelocity = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool forwardpress = Input.GetKey("w");
        bool leftpress = Input.GetKey("a");
        bool rightpress = Input.GetKey("d");
        bool runpress = Input.GetKey("left shift");

        float currentmaxvelocity = runpress ? maxRunVelocity : maxWalkVelocity;

        if (forwardpress && VelocityZ < currentmaxvelocity)
        {
            VelocityZ += Time.deltaTime * accelaration;
        }
        if (leftpress && VelocityX >-currentmaxvelocity)
        {
            VelocityX -= Time.deltaTime * accelaration;
        }
        if (rightpress && VelocityX < currentmaxvelocity)
        {
            VelocityX += Time.deltaTime * accelaration;
        }

        if (!forwardpress && VelocityZ>0.0f)
        {
            VelocityZ -= Time.deltaTime * deceleration;
        }
        if (!forwardpress && VelocityZ < 0.0f)
        {
            VelocityZ = 0.0f;
        }
        if (!leftpress && VelocityX < 0.0f)
        {
            VelocityX += Time.deltaTime * deceleration;
        }
        if (!rightpress && VelocityX > 0.0f)
        {
            VelocityX -= Time.deltaTime * deceleration;
        }
        if (!leftpress && !rightpress && VelocityX!= 0.0f && (VelocityX > -0.05f && VelocityX <0.05f))
        {
            VelocityX = 0.0f;
        }
        if(forwardpress && runpress && VelocityZ >currentmaxvelocity)
        {
            VelocityZ = currentmaxvelocity;
        }
        else if(forwardpress && VelocityZ >currentmaxvelocity)
            {
            VelocityZ -= Time.deltaTime * deceleration;
            if(VelocityZ >currentmaxvelocity &&VelocityZ <(currentmaxvelocity +0.05f))
            {
                VelocityZ = currentmaxvelocity;
            }

        }else if(forwardpress && VelocityZ < currentmaxvelocity && VelocityZ >(currentmaxvelocity -0.05f))
            {
            VelocityZ = currentmaxvelocity;
        }
       


        animator.SetFloat("VelocityX", VelocityX);
        animator.SetFloat("VelocityZ", VelocityZ);

    }
}
