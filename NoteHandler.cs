using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    public KeyCode keyToPress; // D, F, J, K ? ??
    private bool isInHitZone = false; // Hitline? ????? ??

    void Update()
    {
        // ?? Hitline? ??, ??? ?? ??? ?
        if (isInHitZone && Input.GetKeyDown(keyToPress))
        {
            Debug.Log($"Note Hit with key: {keyToPress}");
            Destroy(transform.parent.gameObject); // ?? ?? ??
        }
        else if (Input.GetKeyDown(keyToPress))
        {
            Debug.Log($"Key {keyToPress} pressed, but not in hit zone.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // HitlineD, HitlineF, HitlineJ, HitlineK ?? ??
        if (other.CompareTag($"Hitline{keyToPress.ToString()}"))
        {
            isInHitZone = true;
            Debug.Log($"Entered hit zone: {keyToPress}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag($"Hitline{keyToPress.ToString()}"))
        {
            isInHitZone = false;
            Debug.Log($"Exited hit zone: {keyToPress}");
        }
    }
}
