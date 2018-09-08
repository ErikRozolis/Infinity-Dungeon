using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject player;
    public GameObject cam;
    public GameObject dungeon;

    Animator animator;    
    PlayerController playerController;
    CameraController cameraController;
    DungeonController dungeonController;

	// Use this for initialization
	void Start () {

        animator = this.gameObject.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        cameraController = cam.GetComponent<CameraController>();
        dungeonController = dungeon.GetComponent<DungeonController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            animator.Play("DoorOpen");
            playerController.FreezePlayer();
            cameraController.FadeIntoBlack();
            dungeonController.LoadDungeon();
        }   
    }
}
