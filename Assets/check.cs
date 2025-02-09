using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    public GameObject chains;
    public GameObject YouWin;


    private void Start()
    {
        YouWin.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (chains == null)
        {
            YouWin.SetActive(true); 
        }
    }
}
