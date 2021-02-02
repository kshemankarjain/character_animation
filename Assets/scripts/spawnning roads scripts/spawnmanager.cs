    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    roadspawnner Roadspawnner;
    plotspawnner Plotspawnner;
    //object_move_forward Object_Move_Forward;

    // Start is called before the first frame update
    void Start()
    {
        Roadspawnner = GetComponent<roadspawnner>();
        Plotspawnner = GetComponent<plotspawnner>();
      //  Object_Move_Forward = GetComponent<object_move_forward>();
    }

    public void SpawnTriggerEnter()
    {
       // Object_Move_Forward.pause_car_movement = true;
        Roadspawnner.moveroad_func();
        Plotspawnner.spawnplot();
       // Object_Move_Forward.reset_object_position();
    }
}
