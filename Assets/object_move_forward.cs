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
    private void Awake()
    {
        initial_object_position = transform.localPosition;

    }
    void Start()
    {
        
    }

    void Update()
    {
       // transform.Translate(direction * (Time.deltaTime * (distance / time)));

        float step = speed * Time.deltaTime; // calculate distance to move
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, step);

        //// Check if the position of the cube and sphere are approximately equal.
        //if (Vector3.Distance(transform.position, target.position) < 0.001f)
        //{
        //    // Swap the position of the cylinder.
        //    target.position *= -1.0f;
        //}
    }

    public void reset_object_position()
    {
         transform.localPosition = initial_object_position;
        Debug.Log( " initial position : " + initial_object_position + "  new position: " + transform.localPosition);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, step);

    }
}
