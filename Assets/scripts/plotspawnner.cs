using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotspawnner : MonoBehaviour
{
    private int initAmount = 5;
    private float plotsize = 60f;
    private float xposleft = 0f;
    private float xposright = -12f;
    private float lastzpos = 15f;

    public List<GameObject> plots;
    // Start is called before the first frame update
    void Start()
    {
        for(int i= 0; i<initAmount;i++)
        {
            spawnplot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnplot()
    {
        GameObject plotleft = plots[Random.Range(0, plots.Count)];
        GameObject plotright = plots[Random.Range(0, plots.Count)];

        float Zpos = lastzpos + plotsize;

        Instantiate(plotleft, new Vector3(xposleft, 0.126f, Zpos), plotleft.transform.rotation);
        Instantiate(plotright, new Vector3(xposright, 0.126f, Zpos), new Quaternion(0, 180, 0, 0));
        lastzpos += plotsize;
    }
}
