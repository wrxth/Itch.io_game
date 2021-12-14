using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour, Iinteract
{
    public bool insideCloset;

    private Animator closetAnim;
    private AudioSource closetSound;
    private Movement mov;
    private GameObject hidePosition;
    private GameObject exitPosition;
    private GameObject Player;
    public bool closetCooldownCheck;
    private float closetCooldownTime;
    private float closetCooldownCurrent;

    private void Start()
    {
        closetAnim = gameObject.GetComponent<Animator>();
        closetSound = gameObject.GetComponent<AudioSource>();
        hidePosition = gameObject.transform.GetChild(3).gameObject;
        exitPosition = gameObject.transform.GetChild(4).gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        mov = Player.GetComponent<Movement>();
    }

    private void Update()
    // Constantly updates a variable which is used to make cooldown on hiding possible
    {
        closetCooldownCurrent += Time.fixedDeltaTime;

        if (closetCooldownCurrent <= closetCooldownTime)
        {
            closetCooldownCheck = true;
        }
        if (closetCooldownCurrent >= closetCooldownTime)
        {
            closetCooldownCheck = false;
        }
    }

    public void Interact()
    {
        if (!insideCloset && !closetCooldownCheck)
        // If the player is not inside the closet and there is no cooldown it will transport them inside the closet and set the bool to true
        // Also disables collision, gravity and movement. Plays animation and audio as well
        {
            closetAnim.SetTrigger("Interaction");
            closetSound.Play();
            Player.GetComponent<CapsuleCollider>().enabled = false;
            Player.GetComponent<Rigidbody>().useGravity = false;
            GameObject.FindGameObjectWithTag("Player").transform.position = hidePosition.transform.position;
            insideCloset = true;
            mov.canWalk = false;
            closetCooldownTime = closetCooldownCurrent + 2;
        }

        else if (insideCloset && !closetCooldownCheck)
        // If the player in inside the closet and there is no cooldown it will transport them outside the closet and set the bool to false
        // Also enables collision, gravity and movement. Plays animation and audio as well
        {
            closetAnim.SetTrigger("Interaction");
            closetSound.Play();
            GameObject.FindGameObjectWithTag("Player").transform.position = exitPosition.transform.position;
            Player.GetComponent<CapsuleCollider>().enabled = true;
            Player.GetComponent<Rigidbody>().useGravity = true;
            insideCloset = false;
            mov.canWalk = true;
            closetCooldownTime = closetCooldownCurrent + 2;
        }
    }
}
