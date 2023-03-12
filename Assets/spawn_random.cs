using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_random : MonoBehaviour
{

    public GameObject obstacle_1;
    public GameObject obstacle_2;
    public GameObject obstacle_3;
    public GameObject obstacle_4;
    public GameObject obstacle_5;
    public GameObject obstacle_6;
    public GameObject obstacle_7;
    public GameObject obstacle_8;
    public GameObject obstacle_9;


    void Start()
    {
        obstacle_1.SetActive(false);
        obstacle_2.SetActive(false);
        obstacle_3.SetActive(false);
        obstacle_4.SetActive(false);
        obstacle_5.SetActive(false);
        obstacle_6.SetActive(false);
        obstacle_7.SetActive(false);
        obstacle_8.SetActive(false);
        obstacle_9.SetActive(false);

        int random = Random.Range(1, 11);
        if(random == 1)
        {
            obstacle_1.SetActive(true);
        }
        if (random == 2)
        {
            obstacle_2.SetActive(true);
        }
        if (random == 3)
        {
            obstacle_3.SetActive(true);
        }
        if (random == 4)
        {
            obstacle_4.SetActive(true);
        }
        if (random == 5)
        {
            obstacle_5.SetActive(true);
        }
        if (random == 6)
        {
            obstacle_6.SetActive(true);
        }
        if (random == 7)
        {
            obstacle_7.SetActive(true);
        }
        if (random == 8)
        {
            obstacle_8.SetActive(true);
        }
        if (random == 9)
        {
            obstacle_9.SetActive(true);
        }
    }
}
