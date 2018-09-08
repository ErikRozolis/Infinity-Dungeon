using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    
    public GameObject player;

    int desiredZoom, zoomSpeed;
    Tilemap castleBattleBackground;
    SpriteRenderer backgroundRenderer;
    bool fadeOn, fadeComplete;
    float fadeSpeed, fadeLevel;
    Camera cam;

    // Use this for initialization
    void Start () {
        cam = this.gameObject.GetComponent<Camera>();
        player = GameObject.Find("Player");
        backgroundRenderer = GetComponentInChildren<SpriteRenderer>();

        cam.orthographicSize = 5; //set starting zoom level
        desiredZoom = 5; //set desired zoom level to be same as starting zoom level

        fadeOn = false; // Fade is OFF, showing full screen.
        fadeSpeed = 1.0f;
        fadeComplete = true;
        backgroundRenderer.color = new Color(0, 0, 0, 0f);
    }

    private void Update()
    {
        ApplyZoom();
        ApplyFade();
    }

    public void Zoom(int distance, int speed = 5)
    {
        desiredZoom = distance;
        
        zoomSpeed = speed;
    }

    public void FadeIntoBlack()
    {
        fadeOn = true;
        fadeComplete = false;
    }

    public bool FadeComplete()
    {
        return fadeComplete;
    }

    public void FadeOutOfBlack()
    {
        fadeOn = false;
        fadeComplete = false;
    }

    private void ApplyZoom()
    {
        if (cam.orthographicSize < desiredZoom)
        {
            cam.orthographicSize += Time.deltaTime * zoomSpeed;
            if (cam.orthographicSize > desiredZoom)
                cam.orthographicSize = desiredZoom;
        }
        else if(cam.orthographicSize > desiredZoom)
        {
            cam.orthographicSize -= Time.deltaTime * zoomSpeed;
            if (cam.orthographicSize < desiredZoom)
                cam.orthographicSize = desiredZoom;
        }
    }

    private void ApplyFade()
    {
        if(fadeComplete != true)
        {
            if (fadeOn)
            {
                if (fadeLevel <= 1)
                {
                    fadeLevel += Time.deltaTime * fadeSpeed;
                    if (fadeLevel > 1)
                    {
                        fadeLevel = 1;
                        fadeComplete = true;
                    }
                    backgroundRenderer.color = new Color(0, 0, 0, fadeLevel);
                }
            } else if (!fadeOn)
            {
                if (fadeLevel >= 0)
                {
                    fadeLevel -= Time.deltaTime * fadeSpeed;
                    if (fadeLevel < 0)
                    {
                        fadeLevel = 0;
                        fadeComplete = true;
                    }
                    backgroundRenderer.color = new Color(0, 0, 0, fadeLevel);
                }
            }
        }
    }
}
