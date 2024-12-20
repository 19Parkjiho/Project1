using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public float speed = 5f; // ??? ???? ??

    void Update()
    {
        // Z? ???? ??
        transform.Translate(0, 0, -speed * Time.deltaTime);

        // ?? ??? ???? ??
        if (transform.position.z < -10f) // Hitline ??? ????
        {
            Destroy(gameObject);
        }
    }
}
