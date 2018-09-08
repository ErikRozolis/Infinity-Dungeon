using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonController : MonoBehaviour {

    public GameObject startMenu;
    public Camera cam;
    public GameObject player;
    public GameObject dungeonMap;

    CameraController cameraController;
    PlayerController playerController;
    StartMenuController startMenuController;
    Tilemap tileMap;

    bool dungeonActive, load;
	// Use this for initialization
	void Start () {
        dungeonMap.SetActive(false);
        cameraController = cam.GetComponent<CameraController>();
        playerController = player.GetComponent<PlayerController>();
        startMenuController = startMenu.GetComponent<StartMenuController>();

        load = false;
        dungeonActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (load)
        {
            if (!dungeonActive && cameraController.FadeComplete())
            {
                dungeonActive = true;
                startMenuController.DisableStartMenu();
                dungeonMap.SetActive(true);
                player.transform.position = new Vector3(0, 0.5f, 0);
                cameraController.FadeOutOfBlack();
                cameraController.Zoom(10, 5);
            }
            else if (dungeonActive && cameraController.FadeComplete())
            {
                load = false;
                playerController.UnFreezePlayer();
            }
        }
    }


    public void LoadDungeon()
    {
        load = true;
    }
}
