using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private static readonly string[] animationNames = { "kick1", "kick2", "kick3", "punch3" };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F) ||
            Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            PlayRandomAnimation();
        }
    }

    void PlayRandomAnimation()
    {
        // ?? ????? ??
        int randomIndex = Random.Range(0, animationNames.Length);
        string selectedAnimation = animationNames[randomIndex];

        // ????? ?? ??
        animator.CrossFade(selectedAnimation, 0.1f);
    }
}
