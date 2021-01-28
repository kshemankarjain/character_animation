    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    roadspawnner Roadspawnner;
    plotspawnner Plotspawnner;
    // Start is called before the first frame update
    void Start()
    {
        Roadspawnner = GetComponent<roadspawnner>();
        Plotspawnner = GetComponent<plotspawnner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTriggerEnter()
    {
        Roadspawnner.moveroad();
        Plotspawnner.spawnplot();
    }
}
