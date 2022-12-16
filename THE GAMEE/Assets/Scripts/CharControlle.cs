using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControlle : MonoBehaviour
{
   
    private float horizontalMove;
    private float verticalMove;
    public CharacterController playerController;
    public GameObject player;
    [SerializeField]
    public GameObject playerImage;
    public float PlayerSpeed;
    public float speedBase;
    public float rotationSpeed;   
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        animator = player.GetComponent<Animator>();
        speedBase = PlayerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("left shift")&& !animator.GetBool("isSprinting"))
        {
            animator.SetBool("isSprinting", true);
            PlayerSpeed = PlayerSpeed * 2;
        }
        if (Input.GetKeyUp("left shift"))
        {
            PlayerSpeed = speedBase;
            animator.SetBool("isSprinting", false);
        }
    }

    private void FixedUpdate()
    {
        
        playerController.Move(new Vector3(horizontalMove, 0, verticalMove) * PlayerSpeed * Time.deltaTime);
        Vector3 movementDirection = new Vector3(horizontalMove, 0, verticalMove);
        movementDirection.Normalize();
        if (movementDirection!=Vector3.zero)
        {
            transform.forward = movementDirection;
        }
        if (horizontalMove!=0 || verticalMove!=0)
        {
            Debug.Log("deberia animarse");
            animator.SetBool("isMoving", true);
        }
        if (horizontalMove==0 && verticalMove==0)
        {
            animator.SetBool("isMoving", false);
        }
      
    }
}
