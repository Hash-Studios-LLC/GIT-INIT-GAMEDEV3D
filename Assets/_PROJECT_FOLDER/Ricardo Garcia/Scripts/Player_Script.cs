using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator character_animator;
    public float move_mult = 1;

    private float timer = 0.05f;
    private bool start_timer = false;

    public ParticleSystem shoot_particle;
    public AudioSource gun_sound_1;
    public AudioSource gun_sound_2;
    float fire_rate = 0.2f;
    bool start_fire_rate = false;

    void Update()
    {

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// animator

        if(start_timer == true)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                character_animator.SetInteger("state", 0);
                timer = 0.05f;
                start_timer = false;
            }
        }

        //jump
        if (Input.GetKey("w") && start_timer == false)
        {
            character_animator.SetInteger("state", 0);
            character_animator.SetInteger("state", 3);
            start_timer = true;
        }

        //roll
        if (Input.GetKey("s") && start_timer == false)
        {
            character_animator.SetInteger("state", 0);
            character_animator.SetInteger("state", 4);
            start_timer = true;
        }

        if(Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKeyUp("w") || Input.GetKeyUp("s"))
        {
            character_animator.SetInteger("state", 0);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //player position

        //left
        if (Input.GetKey("d") && this.transform.position.x < 11.5)
        {
            character_animator.SetInteger("state", 0);
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x + Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
            character_animator.SetInteger("state", 2);
        }
        //right
        if (Input.GetKey("a") && this.transform.position.x > 4.7)
        {
            character_animator.SetInteger("state", 0);
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x - Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
            character_animator.SetInteger("state", 1);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //shoot

        if(start_fire_rate == true)
        {
            fire_rate = fire_rate - Time.deltaTime;
            if (fire_rate <= 0)
            {
                start_fire_rate = false;
                fire_rate = 0.2f;
            }
        }

        if (Input.GetMouseButtonDown(0) && start_fire_rate == false) 
        {
            shoot_particle.Play();
            int random = Random.Range(0, 2);
            if(random == 0)
            {
                gun_sound_1.Play();
            }
            if (random == 1)
            {
                gun_sound_2.Play();
            }
            start_fire_rate = true;

        }


    }



}
