using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_cams : MonoBehaviour
{

    public GameObject cam_1;
    public GameObject cam_2;
    public GameObject cam_3;
    public Player_Script script_player;
    public AudioSource click_sound;


    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            click_sound.Play();
            if (cam_1.activeInHierarchy == true)
            {
                cam_1.SetActive(false);
                cam_2.SetActive(true);
                cam_3.SetActive(false);
                script_player.left = "d";
                script_player.right = "a";
            }
            else if (cam_2.activeInHierarchy == true)
            {
                cam_1.SetActive(false);
                cam_2.SetActive(false);
                cam_3.SetActive(true);
                script_player.left = "d";
                script_player.right = "a";
            }
            else if (cam_3.activeInHierarchy == true)
            {
                cam_1.SetActive(true);
                cam_2.SetActive(false);
                cam_3.SetActive(false);
                script_player.left = "a";
                script_player.right = "d";
            }
        }    
    }
}
