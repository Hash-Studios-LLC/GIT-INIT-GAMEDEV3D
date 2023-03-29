using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class start_game : MonoBehaviour
{

    public GameObject main_game;
    public GameObject menu;
    public Player_Script script_player;
    public Animator character_animator;
    public GameObject fx_start;

    public TextMeshProUGUI name_text;
    public TextMeshProUGUI current_text_name;

    public GameObject play_button;
    public GameObject input_GO;
    public GameObject score_go;

    public TextMeshProUGUI highestscore_text;
    

    public void start_the_game()
    {
        fx_start.SetActive(true);
        character_animator.SetInteger("state", 0);
        main_game.SetActive(true);
        script_player.enabled = true;
        menu.SetActive(false);
        play_button.SetActive(false);
        score_go.SetActive(true);
    }

    private void Start()
    {
       // PlayerPrefs.SetInt("highscore", 0);
        character_animator.SetInteger("state", -2);

        if (PlayerPrefs.HasKey("highscore"))
        {
            highestscore_text.text = PlayerPrefs.GetString("highscoreName")+ ": " + PlayerPrefs.GetInt("highscore");
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(current_text_name.text.Length > 1)
            {
                name_text.text = current_text_name.text;
                input_GO.SetActive(false);
            }
        }
    }
}
