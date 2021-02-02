using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_move_forward : MonoBehaviour
{
    Vector3 direction;
     public Transform target;
    float distance;
    Vector3 initial_object_position;

    float time = 1.0f;//seconds
    public float speed = 1.0f;
  
    void Start()
    {
        //initial_object_position = transform.localPosition;

    }

    void Update()
    {
       // transform.Translate(direction * (Time.deltaTime * (distance / time)));
       if(pause_car_movement== false)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
      
      

        //// Check if the position of the cube and sphere are approximately equal.
        //if (Vector3.Distance(transform.position, target.position) < 0.001f)
        //{
        //    // Swap the position of the cylinder.
        //    target.position *= -1.0f;
        //}
    }
    public bool pause_car_movement = false;
    public void reset_object_position()
    {
       
        float z_pos = transform.position.z +(- 5f);
         transform.position = new Vector3(transform.position.x,transform.position.y,z_pos);
        Debug.Log("  new position: " + transform.position);
        //*float step = speed * Time.deltaTime;* calculate distance to move
        pause_car_movement = false;

    }
}
