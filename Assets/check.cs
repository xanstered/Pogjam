using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class check : MonoBehaviour
{
    public GameObject chains;
    


  
    // Update is called once per frame
    void Update()
    {
        if (!chains.activeInHierarchy) 
        {
            SceneManager.LoadScene("YouWin");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
