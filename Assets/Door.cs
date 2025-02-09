using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("isOpen", isOpen);

    }

    // Update is called once per frame
    public void DoorOpen()
    {
        if(animator != null)
        {
            isOpen = true;
            animator.SetBool("isOpen", isOpen);
        }
       
    }
}
