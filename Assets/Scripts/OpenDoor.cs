using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animObj;
    bool opened = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchAnim()
    {
        if (opened == false)
        {
            animObj.SetBool("isOpen", true);
            opened = true;
        }
        else
        {
            animObj.SetBool("isOpen", false);
        }
    }
}
