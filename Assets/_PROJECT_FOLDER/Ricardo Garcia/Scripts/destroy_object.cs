using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_object : MonoBehaviour
{
    public GameObject spawn_prefab;
    public Transform prefab_location;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            Instantiate(spawn_prefab, prefab_location.transform.position, prefab_location.transform.rotation);
        }
    }
}
