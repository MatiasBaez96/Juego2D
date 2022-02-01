using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Base_Code : MonoBehaviour
{
    //public Collider2D ColliderVar;
    public IDoAction DoActionVar;

    public void Interaction(Collider2D Var)
    {     
      DoActionVar.DoAction(Var);
    }
}

