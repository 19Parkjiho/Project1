using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveDuration = 0.01f; // ??? ??? ?? (?)
    private Rigidbody characterRigidbody;
    private float targetX;
    private bool isMoving = false;
    private Vector3 startPosition;
    private float moveStartTime;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        targetX = transform.position.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartMove(-4.5f);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            StartMove(-1.5f);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            StartMove(1.5f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            StartMove(4.5f);
        }

        if (isMoving)
        {
            float elapsed = (Time.time - moveStartTime) / moveDuration;
            if (elapsed < 1f)
            {
                float newX = Mathf.Lerp(startPosition.x, targetX, elapsed);
                Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
                characterRigidbody.MovePosition(newPosition);
            }
            else
            {
                isMoving = false;
                characterRigidbody.MovePosition(new Vector3(targetX, transform.position.y, transform.position.z));
            }
        }
    }

    void StartMove(float newTargetX)
    {
        startPosition = transform.position;
        targetX = newTargetX;
        moveStartTime = Time.time;
        isMoving = true;
    }
}