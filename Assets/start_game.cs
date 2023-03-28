using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_game : MonoBehaviour
{

    public GameObject main_game;
    public GameObject menu;
    public Player_Script script_player;
    public Animator character_animator;
    public GameObject fx_start;

    private void Start()
    {
        character_animator.SetInteger("state", -2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            fx_start.SetActive(true);
            character_animator.SetInteger("state", 0);
            main_game.SetActive(true);
            script_player.enabled = true;
            menu.SetActive(false);
        }
    }
}
