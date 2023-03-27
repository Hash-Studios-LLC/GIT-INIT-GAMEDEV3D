using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Player_Script script_player = other.gameObject.GetComponent<Player_Script>();
            script_player.kill_player();
        }
    }
}
