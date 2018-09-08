using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransitionType { Walk, Teleport, Fade }

public class PadController : MonoBehaviour {

    public GameObject TargetPoint;
    public TransitionType Transition;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            List<Vector2> destinations = new List<Vector2>
            {
                this.gameObject.transform.position,
                TargetPoint.transform.position
            };
            GameObject player = collision.gameObject;
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.GuidedMovePlayer(destinations);
        }
    }
}
