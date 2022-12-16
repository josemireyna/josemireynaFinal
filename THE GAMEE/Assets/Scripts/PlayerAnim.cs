using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    BoxCollider boxcollider;
    public GameObject player;
    [SerializeField]
    GameObject canvas;
    AudioSource audio;
    private void Start()
    {
        animator = player.GetComponent<Animator>();
        characterController = player.GetComponent<CharacterController>();
        boxcollider = player.GetComponent<BoxCollider>();
        audio = gameObject.GetComponent<AudioSource>();
        GetRagdollBits();
        RagdollModeOff();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canvas.SetActive(true); 
            animator.enabled = false;
            characterController.enabled = false;
            audio.Play();
        }

    }
    private void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RagdollModeON();
        }
    }
    Collider[] ragdollColliders;
    void GetRagdollBits()
    {
        ragdollColliders = player.GetComponentsInChildren<Collider>();
    }
    void RagdollModeOff()
    {
        foreach(Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
       
        boxcollider.enabled = true;
        animator.enabled = true;
        characterController.enabled = true;
        
    }
    
    void RagdollModeON()
    {
        animator.enabled = false;
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
        
        boxcollider.enabled = false;
        characterController.enabled = false;
        audio.Play();
        LoseGame();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Finish")
        {
            
            RagdollModeON();
        }
    }
    private void LoseGame()
    {
        canvas.SetActive(true);
    }
}
