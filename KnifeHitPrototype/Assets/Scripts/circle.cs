using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class circle : MonoBehaviour {

    public static int life;
    public static Animator anim;
	// Use this for initialization
	void Start () {
        life = (int) Math.Ceiling(gameManager.wave * 1.5);
        anim = GetComponent<Animator>();
	}
    
	
	// Update is called once per frame
	void Update () {
        
	}
}
