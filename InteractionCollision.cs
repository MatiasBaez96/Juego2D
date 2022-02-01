using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollision : MonoBehaviour
{
   //e tiene que hacer la cmprobacion ocn la clase que aparece en el inspector    
}
public interface IDoAction
{
 void DoAction(Collider2D Collider);
}
public class ObjectInteraction : IDoAction
{
 public GameObject Jonh;
 public ExtraFuntions CallFuntion;

  public ObjectInteraction()
  {
   GameObject Jonh = GameObject.Find("john");
   CallFuntion = Jonh.GetComponent<ExtraFuntions>();
  }
  public void DoAction(Collider2D Collision)
  {
    ObjectInteraction NewObject = new ObjectInteraction();

    InteractionCollision Life = Collision.GetComponent<InteractionCollision>();
    if (Jonh != null)
    {          
     //Create Life Funtion
    }
    Vida Heart = Collision.GetComponentInChildren<Vida>();
    if (Heart != null)
    {
            Debug.Log("Energy Funtion");
     NewObject.CallFuntion.Energia();
    }
  }
}

