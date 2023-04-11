using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_player : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosion_transparent;

    public void explode()
    {
        explosion.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void explode2()
    {
        explosion_transparent.SetActive(true);
        this.gameObject.SetActive(false);
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Player_Script script_player = other.gameObject.GetComponent<Player_Script>();
            script_player.kill_player();
        }
    }
}
