using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public Animator character_animator;

    private void Start()
    {
        character_animator.SetInteger("state", 6);
    }

    void Update()
    {

    }



}
