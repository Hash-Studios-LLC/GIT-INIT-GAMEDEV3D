using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_map : MonoBehaviour
{
    public float speed = 1;
    public Player_Script script_player;


    void Update()
    {
        if (script_player != null)
        {
            speed = script_player.map_speed;
        }

        Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        move.z = move.z + Time.deltaTime * speed;
        this.transform.SetPositionAndRotation(move, this.transform.rotation);
    }
}
