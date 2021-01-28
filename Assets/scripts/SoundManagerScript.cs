using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip player_jump, player_collide, player_run, gamesound;
    static AudioSource audioscr;
    // Start is called before the first frame update
    void Start()
    {
        player_jump = Resources.Load<AudioClip>("playerjumping");
        player_collide = Resources.Load<AudioClip>("playercollide");
        player_run = Resources.Load<AudioClip>("playerrun");
        gamesound = Resources.Load<AudioClip>("gamesound");

        audioscr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playsound (string clip)
    {
        switch(clip)
        {
            case "playerjumping":
                audioscr.PlayOneShot(player_jump);
                
                    break;
            case "gamesound":
                audioscr.PlayOneShot(gamesound,0.3f);
                break;
            case "playercollide":
                audioscr.PlayOneShot(player_collide);
                break;
        }
            
        
    }
    public static void stopsound()
    {
        audioscr.Stop();
    }
}
