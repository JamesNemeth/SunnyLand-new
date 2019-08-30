using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    //member variables
    public float jumpHeight = 5f;   //how high the character jumps
    public float climbSpeed = 10f;  // how fast the character climbs
    public float moveSpeed = 10f;  //how fast the character moves

    private CharacterController2D controller;
    
    // Start is called before the first frame update
    void Start()
    {
        // gather components at the start of the game to save processing
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        * --- Unity Tip
        * Input.GetAxis 
        * Input.GetAxisRaw
        */

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        if (isJumping)
        {
            controller.Jump(jumpHeight);
        }

        controller.Climb(vertical * climbSpeed);

         // move controller horizontally
        controller.Move(horizontal * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item") 
        {
            //Detect hitiing item
            //Add 1 score
            GameManager.Instance.Addscore(1);
            //Play Chime sound
            Destroy(col.gameObject);
        }

    }
}
