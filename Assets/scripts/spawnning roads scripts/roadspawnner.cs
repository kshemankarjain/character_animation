using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class roadspawnner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 25f;
    // Start is called before the first frame update
    object_move_forward object_Move_Forward;


    void Start()
    {
        object_Move_Forward = GetComponent<object_move_forward>();
        if (roads !=null && roads.Count>0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }
    GameObject moveroad;
    bool car_found = false;

  public void moveroad_func()
  {
        moveroad = roads[0];
        roads.Remove(moveroad);
        float NewZ = roads[roads.Count - 1].transform.position.z + offset;
        moveroad.transform.position = new Vector3(0, 0, NewZ);
     

        //if (moveroad.transform.GetChild(3).name == "Sedan_creased")
        //{
        //    car_found = true;
        //     moveroad.transform.GetChild(3).Translate(Vector3.forward * 10.0f);
        //}
        //else
        //    car_found = false;

        roads.Add(moveroad);
  }
   // private void FixedUpdate()
    //{
    //    if (car_found)
    //    {
    //        if (moveroad.transform.GetChild(3).name == "Sedan_creased")
    //        {
                 
    //            // moveroad.transform.GetChild(3).Translate(Vector3.forward * 10.0f);
    //            moveroad.transform.GetChild(3).GetComponent<Rigidbody>().position
               
    //        }
    //    }
    //    else
    //    {
    //        car_found = false;
    //    }
   // }
}
