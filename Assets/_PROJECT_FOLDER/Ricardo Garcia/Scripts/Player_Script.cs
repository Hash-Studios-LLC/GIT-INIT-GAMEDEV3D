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

    bool player_is_alive = true;
    public float map_speed = 1;
    float map_timer = 8f;
    public AudioSource loose_sound;
    public AudioSource background_music;
    public AudioSource impact_sound;
    public GameObject jar;
    public float jar_speed = 2;


    public void kill_player()
    {
        player_is_alive = false;
        map_speed = 0;
        character_animator.SetInteger("state", -1);
        background_music.Stop();
        loose_sound.Play();
        impact_sound.Play();
    }


    void Update()
    {

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// animator

        if(start_timer == true && player_is_alive == true)
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
        if (Input.GetKey("w") && start_timer == false && player_is_alive == true)
        {
            character_animator.SetInteger("state", 0);
            character_animator.SetInteger("state", 3);
            start_timer = true;
        }

        //roll
        if (Input.GetKey("s") && start_timer == false && player_is_alive == true)
        {
            character_animator.SetInteger("state", 0);
            character_animator.SetInteger("state", 4);
            start_timer = true;
        }

        if(Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKeyUp("w") || Input.GetKeyUp("s") && player_is_alive == true)
        {
            character_animator.SetInteger("state", 0);
        }

        if(player_is_alive == false)
        {
            character_animator.SetInteger("state", -1);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //player position

        //left
        if (Input.GetKey("d") && this.transform.position.x < 11.5 && player_is_alive == true)
        {
            character_animator.SetInteger("state", 0);
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x + Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
            character_animator.SetInteger("state", 2);
        }
        //right
        if (Input.GetKey("a") && this.transform.position.x > 4.7 && player_is_alive == true)
        {
            character_animator.SetInteger("state", 0);
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x - Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
            character_animator.SetInteger("state", 1);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //shoot

        if(start_fire_rate == true && player_is_alive == true)
        {
            fire_rate = fire_rate - Time.deltaTime;
            if (fire_rate <= 0)
            {
                start_fire_rate = false;
                fire_rate = 0.2f;
            }
        }

        if (Input.GetMouseButtonDown(0) && start_fire_rate == false && player_is_alive == true) 
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //map speed

        if(player_is_alive == true)
        {
            map_timer = map_timer - Time.deltaTime;
            if (map_timer <= 0)
            {
                map_speed = map_speed + 5;
                map_timer = 8f;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //move jar
        if(player_is_alive == false)
        {
            Vector3 jar_position = jar.transform.position;
            jar_position.z = jar_position.z - Time.deltaTime*jar_speed;
            jar.transform.SetPositionAndRotation(jar_position, jar.transform.rotation);
        }



    }



}
