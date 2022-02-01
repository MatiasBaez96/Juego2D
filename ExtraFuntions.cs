using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFuntions : MonoBehaviour
{
    [SerializeField] private int Energia1 = 25;
    [SerializeField] private int Damage = 25;
    [SerializeField] private int CurrentLife;
    [SerializeField] private int CurrentHealth = 100;

    [SerializeField] private ScriptVar ScriptVarComp;

    [SerializeField] private AudioClip BulletHurt;
    [SerializeField] private AudioClip TakeLife;

    [SerializeField]private Animator AnimatorVar;
   
    [SerializeField]private Rigidbody2D RigidBody2D;

    [SerializeField]private GameObject HeartLife; 

    [SerializeField] private GameObject DestroyObjectGO; 

    
    public void Hit()
    {
     Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletHurt);
     ScriptVarComp.SetHealth(Damage);
     CurrentHealth -= Damage;
     if (CurrentHealth <= 0) Die();
    }
    private void Die()
    {
     AnimatorVar.SetTrigger("MuerteAnimacion");

     RigidBody2D.velocity = new Vector2(0, 5);

     Invoke("DestruirJugador", 0.4f);     
    }
    private void DestruirJugador()
    {
     gameObject.SetActive(false);
    }
    public void Energia()
    {     
     DestroyObjectGO.gameObject.SetActive(false);
      
     Camera.main.GetComponent<AudioSource>().PlayOneShot(TakeLife);
     HeartLife.gameObject.SetActive(false);
     Variables.CurrentHealth += 20;
     ScriptVarComp.RecibeVida(Energia1);     
    }
    public void LifeSystem(int Life)
    {
        
    }
}
