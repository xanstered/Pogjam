using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour,IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
       
        animator.SetBool("isOpen", isOpen);
    }
    public void Interact()

    {
        if (animator != null)
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }

    }

}
