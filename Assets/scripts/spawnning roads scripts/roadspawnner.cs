using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class roadspawnner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 25f;
    // Start is called before the first frame update
   //public object_move_forward Object_Move_Forward;


    void Start()
    {
      //  Object_Move_Forward = GetComponent<object_move_forward>();
        if (roads !=null && roads.Count>0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }
    GameObject moveroad;
   

  public void moveroad_func()
  {
        moveroad = roads[0];
        roads.Remove(moveroad);
        float NewZ = roads[roads.Count - 1].transform.position.z + offset;
        moveroad.transform.position = new Vector3(0, 0, NewZ);
        roads.Add(moveroad);
        //Object_Move_Forward.reset_object_position(moveroad.transform.position);

        if (moveroad.transform.GetChild(3).name == "Sedan_creased")
        {
            if (moveroad.transform.GetChild(3).transform.position.x < -8.0f)
            {
                moveroad.transform.GetChild(3).transform.position =new  Vector3(-3.0f, moveroad.transform.GetChild(3).transform.position.y, moveroad.transform.GetChild(3).transform.position.z);
            }
            else
            {
                moveroad.transform.GetChild(3).Translate(Vector3.right * 3f);

            }
        }

       // Object_Move_Forward.reset_object_position();

  }

}
