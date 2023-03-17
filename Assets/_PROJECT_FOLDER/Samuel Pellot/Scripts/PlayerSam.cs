using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSam : MonoBehaviour
{
    public Animator character_animator;
    public float move_mult = 1;

    private float timer = 0.05f;
    private bool start_timer = false;

    void Update()
    {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // animator

        if (start_timer == true)
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
        if (Input.GetAxis("Vertical") >= 0.5 && start_timer == false)
        {
            character_animator.SetInteger("state", 0);
            character_animator.SetInteger("state", 3);
            start_timer = true;
        }

        //roll
        if (Input.GetAxis("Vertical") <= -0.5 && start_timer == false)
        {
            character_animator.SetInteger("state", 0);
            character_animator.SetInteger("state", 4);
            start_timer = true;
        }

        //resets to default animation, replace this if statement.
        /*if (Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKeyUp("w") || Input.GetKeyUp("s"))
        {
            character_animator.SetInteger("state", 0);
        }*/
        //Try this replacement code below, two if statements
        if (Input.GetAxis("Vertical") > -0.5 && Input.GetAxis("Vertical") <= 0 || Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") <= 0.5)
        {
            if (Input.GetAxis("Horizontal") > -0.5 && Input.GetAxis("Horizontal") <= 0 || Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Horizontal") <= 0.5)
                character_animator.SetInteger("state", 0);

        }
        

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //player position

            // go left
            //Check that an input value < 0.25 is being provided
            if (Input.GetAxis("Horizontal") <= -0.5 && this.transform.position.x < 11.5)
            {
            character_animator.SetInteger("state", 0);
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x + Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
            character_animator.SetInteger("state", 2);
            }
        // go right
        //Check that an input value > 0.25 is being provided  
        if (Input.GetAxis("Horizontal") >= 0.5 && this.transform.position.x > 4.7)
        {
            character_animator.SetInteger("state", 0);
            Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            move.x = move.x - Time.deltaTime * move_mult;
            this.transform.SetPositionAndRotation(move, this.transform.rotation);
            character_animator.SetInteger("state", 1);
        }



    }



}
