using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_outfits : MonoBehaviour
{

    public GameObject arrow_up;
    public GameObject arrow_low;

    public AudioSource click_sound;
    public AudioSource click_sound_2;

    public GameObject[] heads;
    public GameObject[] body;

    int active_head = 0;
    int active_body = 0;

    

    void Update()
    {

        if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
        {
            if(arrow_up.activeInHierarchy == true)
            {
                arrow_up.SetActive(false);
                arrow_low.SetActive(true);
                click_sound.Play();
            }

            else if (arrow_low.activeInHierarchy == true)
            {
                arrow_up.SetActive(true);
                arrow_low.SetActive(false);
                click_sound.Play();
            }
        }


        if (Input.GetKeyDown("d"))
        {
            //change heads right
            if (arrow_up.activeInHierarchy == true)
            {
                if(active_head < heads.Length-1)
                {
                    heads[active_head].SetActive(false);
                    active_head = active_head + 1;
                    heads[active_head].SetActive(true);
                    click_sound_2.Play();
                }
            }

            //change body right
            if (arrow_low.activeInHierarchy == true)
            {
                if (active_body < body.Length - 1)
                {
                    body[active_body].SetActive(false);
                    active_body = active_body + 1;
                    body[active_body].SetActive(true);
                    click_sound_2.Play();
                }
            }


        }

        if (Input.GetKeyDown("a"))
        {
            //change heads left
            if (arrow_up.activeInHierarchy == true)
            {
                if (active_head >0)
                {
                    heads[active_head].SetActive(false);
                    active_head = active_head - 1;
                    heads[active_head].SetActive(true);
                    click_sound_2.Play();
                }
            }

            //change body left
            if (arrow_low.activeInHierarchy == true)
            {
                if (active_body > 0)
                {
                    body[active_body].SetActive(false);
                    active_body = active_body - 1;
                    body[active_body].SetActive(true);
                    click_sound_2.Play();
                }
            }

        }


    }
}
