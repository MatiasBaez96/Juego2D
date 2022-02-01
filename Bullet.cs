using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]private float Speed = 8.0f;

    [SerializeField]private Rigidbody2D rigidBody;
    
    [SerializeField]private Vector2 Direction;

    [SerializeField]private AudioClip Sound;

   // [SerializeField]private GameObject BulletGO;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound); //Accedes al componente de la camaara y luego al componente AudioSource //()transform.position = Position;metodo que reproduce un Sonido                                             //Al ser el Start de la bala,el sonido se reproduce cada vez que se instancia una "Bullet" 
    }
    void Update()
    {
        DirectionFuntion(); 
    }
    public void SetDirection(Vector2 direction)
    {
        
        Direction = direction;
        Invoke("DestroyBullet",0.3f);
        DirectionFuntion();    
    }
    private void DirectionFuntion()
    {  
      rigidBody.velocity = Direction.normalized * Speed;   
    }   
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {                                                                                  //Como ya recibe el Collider , no necesitamos buscar el Collider 
                                                                                  //El Is trigger de la bala tiene que estar ACTIVO 

        ExtraFuntions Jonh = collision.GetComponent<ExtraFuntions>(); //Tiene que estar equipado en el jugador 
        Enemy Grunt = collision.GetComponent<Enemy>();
        MuerteRecompensa Enemy2 = collision.GetComponent<MuerteRecompensa>();

        if (Enemy2 != null)
        {
            Enemy2.HitEnemy2();
        }
        if (Jonh != null)
        {
            Jonh.Hit();   
        }
        if (Grunt != null)
        {
            Grunt.Hit();
        }
        Destroy(gameObject); //Cuando Colisiona la bala desaparece 
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movements Jonh = collision.collider.GetComponent<Movements>();
        Enemy Grunt = collision.collider.GetComponent<Enemy>();

        if (Jonh != null)
        {
            
        }
        if (Grunt != null)
        {
            
        }       
       //Las balas que golpean al jugador o enemigo los empuja ,el Is Trigger tiene que estar desactivado
        //si Is Trigger esta activado se deve usar OnTriggerEnter2D(el objeto equipado con el Script debe tener activado el IsTrigger)
    }
}
public  class Bullet2 : MonoBehaviour
{
  
    void Start()
    {
       
    }
    private void Update()
    {
        
    }
    private void BulletDirection()
    {
       
    }     
}


//public class Lifev : Base_Code
//{   
    //equipado en la vida  (collider de la vida )
  //  private void OnTriggerEnter2D(Collider2D collision)
    //{
//        ColliderVar = collision;
  //      DoActionVar = new ObjectInteraction();  //Creo un obejeto que hereda de la interface, y lo alamceno dentro de esa variable 
    //}

//}

//Teoricamente , cada vez que el jugador choque con cualquier objeto va a funcionar 
