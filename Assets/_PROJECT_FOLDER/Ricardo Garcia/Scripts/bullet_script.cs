using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{

    public float timer_to_destroy = 3;
    public float bullet_force = 50;
    public Rigidbody this_rig;

    void Start()
    {
        this_rig.AddForce(0, 0, bullet_force);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            kill_player kill_script = other.gameObject.GetComponent<kill_player>();
            if (kill_script != null)
            {
                kill_script.explode2();
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        timer_to_destroy = timer_to_destroy - Time.deltaTime;
        if(timer_to_destroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
