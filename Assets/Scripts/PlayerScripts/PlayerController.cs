using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    enum PlayerState
    {
        possessed, frozen, free
    }

    float granularity = 0.1f;
    Animator animator;
    Rigidbody2D playerRigidbody;
    PlayerState state;
    List<Vector2> possessedMoveCoords;

    // Use this for initialization
    void Start()
    {

        animator = this.gameObject.GetComponentInChildren<Animator>();
        playerRigidbody = this.gameObject.GetComponentInChildren<Rigidbody2D>();
        possessedMoveCoords = new List<Vector2>();
        state = PlayerState.free;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == PlayerState.free)
            ManuallyMove();
        if (state == PlayerState.possessed)
            PossessedMove();
    }

    public void GuidedMovePlayer(List<Vector2> coordsList, int speed = 5)
    {
        state = PlayerState.possessed;
        playerRigidbody.isKinematic = true;
        possessedMoveCoords = coordsList;
    }

    private void PossessedMove()
    {
        if(possessedMoveCoords.Count > 0)
        {
            Vector2 dir = possessedMoveCoords[0] - (Vector2)this.gameObject.transform.position;
            if (dir.magnitude > granularity)
            {
                animator.SetInteger("Direction", (int)Destination.Directify(dir));
                playerRigidbody.velocity = dir.normalized * 5;
            }
            else
            {
                possessedMoveCoords.RemoveAt(0);
            }
        }
        else
        {
            StopMoving();
            playerRigidbody.isKinematic = false;
            state = PlayerState.free;
        }
        

    }

    public void FreezePlayer()
    {
        StopMoving();
        state = PlayerState.frozen;
    }

    public void UnFreezePlayer()
    {
        state = PlayerState.free;
    }


    private void ManuallyMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 dir = MouseController.GetMousePosition() - (Vector2)this.gameObject.transform.position;
            animator.SetInteger("Direction", (int)Destination.Directify(dir));
            playerRigidbody.velocity = dir.normalized * 5;
        }
        else
        {
            StopMoving();
        }
    }

    private void StopMoving()
    {
        playerRigidbody.velocity = Vector2.zero;
        animator.SetInteger("Direction", (int)Direction.Idle);
    }
}
