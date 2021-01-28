using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_in_direction : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        this.transform.position += Movement * speed * Time.deltaTime;
    }
}
