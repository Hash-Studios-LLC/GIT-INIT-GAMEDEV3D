using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_object : MonoBehaviour
{
    public GameObject spawn_prefab_1;
    public GameObject spawn_prefab_2;
    public GameObject spawn_prefab_3;
    public Transform prefab_location;
    public Player_Script script_player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                GameObject map = Instantiate(spawn_prefab_1, prefab_location.transform.position, prefab_location.transform.rotation);
                move_map map_script = map.GetComponent<move_map>();
                map_script.script_player = this.script_player;
            }
            if (random == 1)
            {
                GameObject map = Instantiate(spawn_prefab_2, prefab_location.transform.position, prefab_location.transform.rotation);
                move_map map_script = map.GetComponent<move_map>();
                map_script.script_player = this.script_player;
            }
            if (random == 2)
            {
                GameObject map = Instantiate(spawn_prefab_3, prefab_location.transform.position, prefab_location.transform.rotation);
                move_map map_script = map.GetComponent<move_map>();
                map_script.script_player = this.script_player;
            }

        }
    }
}
