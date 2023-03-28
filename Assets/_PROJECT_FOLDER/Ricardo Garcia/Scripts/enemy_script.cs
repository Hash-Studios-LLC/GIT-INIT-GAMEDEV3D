using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    public GameObject character;
    public GameObject blood_explosion;

  public void die()
    {
        character.SetActive(false);
        blood_explosion.SetActive(true);
    }
}
