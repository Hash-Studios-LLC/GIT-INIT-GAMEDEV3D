using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Player : MonoBehaviour
{
    public float move_mult = 1;
    public GameObject bullet;
    public Transform bullet_location;

    public AudioSource shot_sound_1;
    public AudioSource shot_sound_2;
    public AudioSource shot_sound_3;

    float fire_rate = 0.5f;
    bool start_timer = false;

    // Update is called once per frame
    void Update()
    {

        if(start_timer == true)
        {
            fire_rate = fire_rate - Time.deltaTime;
            if(fire_rate <= 0)
            {
                fire_rate = 0.5f;
                start_timer = false;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //player 2 position

        //left      
        if (Input.GetAxis("Horizontal2") >= 0.5 && this.transform.position.x < 11.5)
        {
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x + Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
        }
        //right
        if (Input.GetAxis("Horizontal2") <= -0.5 && this.transform.position.x > 4.7)
        {
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x - Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //player 2 SHOOT

        if(Input.GetAxis("Fire2") > 0.5f && start_timer == false)
        {
            GameObject bullet_created = Instantiate(bullet, bullet_location.position, bullet_location.rotation);
            start_timer = true;

            int random = Random.Range(0, 2);
            if(random == 0)
            {
                shot_sound_1.Play();
            }
            else if(random == 1)
            {
                shot_sound_2.Play();
            }
            else
            {
                shot_sound_3.Play();
            }
             
        }



    }
}
