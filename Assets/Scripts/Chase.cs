using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chase : MonoBehaviour {

    public Transform player;
    static Animator anim;
    public Slider healthbar;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        //stops enemy from following player once dead
        if (healthbar.value <= 0) return;

        Vector3 direction = player.position - this.transform.position;
        //gets forward direction of skeleton and direction to player
        float angle = Vector3.Angle(direction, this.transform.forward);
	    if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), .1f * Time.deltaTime);

            anim.SetBool("IsIdle", false);
            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);
            }
            else
            {
                anim.SetBool("IsAttacking", true);
                anim.SetBool("IsWalking", false);
            }
        }	
        else
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
        }
	}
}
