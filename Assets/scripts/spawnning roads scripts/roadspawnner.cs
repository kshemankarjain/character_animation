using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class roadspawnner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 25f;
    // Start is called before the first frame update
    void Start()
    {
        if(roads !=null && roads.Count>0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }

    }

  public void moveroad()
    {
        GameObject moveroad = roads[0];
        roads.Remove(moveroad);
        float NewZ = roads[roads.Count - 1].transform.position.z + offset;
        moveroad.transform.position = new Vector3(0, 0, NewZ);
        if (moveroad.transform.GetChild(3).name == "Sedan_creased")
            moveroad.transform.GetChild(3).Translate(Vector3.up*2.0f);
        roads.Add(moveroad);
    }
}
