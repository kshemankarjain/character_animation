    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    roadspawnner Roadspawnner;
    plotspawnner Plotspawnner;
    public object_move_forward Object_Move_Forward;
    // Start is called before the first frame update
    void Start()
    {
        Roadspawnner = GetComponent<roadspawnner>();
        Plotspawnner = GetComponent<plotspawnner>();
    }

    public void SpawnTriggerEnter()
    {
        Roadspawnner.moveroad_func();
        Plotspawnner.spawnplot();
       
         Object_Move_Forward.reset_object_position();
    }
}
