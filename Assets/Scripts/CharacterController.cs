using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    static Animator anim;
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("IsAttacking", true);
        } else
        {
            anim.SetBool("IsAttacking", false);
        }
        if (translation != 0)
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", true);
        }
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
