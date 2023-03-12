using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator character_animator;

    public Transform center_position;
    public Transform left_position;
    public Transform right_position;
    public Transform current_position;


    private float timer = 0.05f;
    private bool start_timer = false;

    private void Start()
    {
        current_position.position = this.transform.position;
    }


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


        //left
        if (Input.GetKeyDown("a") && start_timer == false)
        {
            character_animator.SetInteger("state", 2);
            start_timer = true;
        }

        //right
        if (Input.GetKeyDown("d") && start_timer == false)
        {
            character_animator.SetInteger("state", 1);
            start_timer = true;
        }

        //jump
        if (Input.GetKeyDown("w") && start_timer == false)
        {
            character_animator.SetInteger("state", 3);
            start_timer = true;
        }

        //roll
        if (Input.GetKeyDown("s") && start_timer == false)
        {
            character_animator.SetInteger("state", 4);
            start_timer = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //player position

        //left
        if (Input.GetKeyDown("a"))
        {
            current_position.position = left_position.position;
        }
        //right
        if (Input.GetKeyDown("d"))
        {
            current_position.position = right_position.position;
        }


    }



}
