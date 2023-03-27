using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode_objects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            kill_player kill_script = other.gameObject.GetComponent<kill_player>();
            if(kill_script != null)
            {
                kill_script.explode();
            }
           
        }
    }
}
