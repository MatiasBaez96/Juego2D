using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Life : Base_Code
{
    private void Start()
    {
        DoActionVar = new ObjectInteraction();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Dentro del evento");
        Interaction(collision);
    }
}

