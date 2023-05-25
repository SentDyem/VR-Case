using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAud : MonoBehaviour
{
    public AudioSource audClip;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audClip.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (audClip.isPlaying == true && animator.velocity != Vector3.zero)
        {
            animator.SetBool("isSpeaking", false);
        }
        else
        {
            animator.SetBool("isSpeaking", true);
        }
    }

    void PlaySound()
    {
       if (audClip.isPlaying == false)
        {
            audClip.Play();
        }
    }
    void PauseSound()
    {
        if (!audClip.isPlaying)
        {
            audClip.Pause();
        }
    }
}
