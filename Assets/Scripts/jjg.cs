﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jjg : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(anim.GetBool("movementkeyspressed") == false)
            {
                anim.SetBool("movementkeyspressed", true);
            }
            else
            {
                anim.SetBool("movementkeyspressed", false);
            }
        }
    }
}
