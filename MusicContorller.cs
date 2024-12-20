using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContorller : MonoBehaviour
{
    public AudioSource audioSource;  // ??? ?? ????

    void Start()
    {
        // 3? ?? ??? ???? ??? ??
        StartCoroutine(StartMusicAfterDelay(0f));
    }

    // ??? ??(?) ?? ??? ???? ???
    IEnumerator StartMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // delay?? ???
        audioSource.Play();  // ?? ??
    }
}
