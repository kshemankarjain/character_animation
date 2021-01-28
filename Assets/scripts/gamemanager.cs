using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    private GameObject player ;
    public Text Uidistance;
    public static bool gameover;
    public GameObject gameoverpanel;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z) -16 ;
        Uidistance.text = "score : " + distance.ToString() + "";
        
        if(gameover)
        {
            Time.timeScale = 0;
            gameoverpanel.SetActive(true);
        }

    }
}
