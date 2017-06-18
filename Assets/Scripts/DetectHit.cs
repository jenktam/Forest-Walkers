using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour {

    public Slider healthbar;
    Animator anim;
    public string opponent;

    private void OnTriggerEnter(Collider other)
    {
        //creates tags for player and enemy and only applies damage to opponent tag. allows script to be run for both enemy and player
        if (other.gameObject.tag != opponent) return;

        healthbar.value -= 30;
        
        if(healthbar.value <= 0)
        {
            anim.SetBool("IsDead", true);
        }
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
