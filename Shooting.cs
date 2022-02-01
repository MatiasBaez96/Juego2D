using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private Transform DownShotNegative;
    [SerializeField] private Transform DownShotPoint;

    [SerializeField]private float LastShot;
    [SerializeField] private float BulletVelocity;
    [SerializeField] private float Velocity;

    [SerializeField]private GameObject BulletGO;
    [SerializeField]private GameObject VariantBullet;

    [SerializeField] private AudioClip BulletSound;

    [SerializeField] private Vector2 DiagonalDirection;

    [SerializeField]private MovementsFuntions CallHorizontal;

    [SerializeField] private Rigidbody2D BulletVariant;                                               //Agregarla dentro de las funciones con velocidad  
    public void SideShots()
    {
      if (Input.GetKey(KeyCode.J) && Time.time > LastShot + 0.25f && !MovementsFuntions.DiagonalActivated && !MovementsFuntions.LookingDownBool && !MovementsFuntions.DifferentiatingShots) //Si el ultimo disparo fue en el seg 3 le sumamos 0.25f, en el segundo 3.25 volve a disparar (Time.time" tiene que ser mas grande)
      {
           
       Animations.ShothingStandingTrue();
       LastShot = Time.time;                                                                           //Almacenamos el tiempo en la variable cuando disparamos             
       Shot();
      }
      else if ((Input.GetKey(KeyCode.J)))
      {                                              
       Animations.ShothingStandingTrue();                                                           //quisas los segundos sumados en el primer condicional,provocan que "Else" se ejecute entre disparos
      }
      else
      {
       Animations.ShothingStandingFalse();
      }
      DiagonalShotUp();     
    }
    public void Shot() 
    {       
     Vector3 direction;

     if (transform.localScale.x == 1.0f) direction = Vector2.right;                                             //else if (transform.localScale.x == -1.0f) direction = Vector2.left;(creo que al no estar el valor definido da error mandando la direccion , "Else" queda defimnido con un valor y lo permite )
     else direction = Vector2.left;

     GameObject BulletObject = Instantiate(BulletGO, transform.position + direction * 0.2F, Quaternion.identity);//Vectore tienen que ser del mismo tipo / direction * 0.1f (en la direccion que este le agrega 0.1 en ofset)
     BulletObject.GetComponent<Bullet>().SetDirection(direction);
    }
    private void DiagonalShotUp()
    {
      if (CallHorizontal.Horizontal != 0.0 && Input.GetKey(KeyCode.W))
      {
       Animations.WhileRunningTrue();     
      }
      else
      {
       Animations.WhileRunningFalse();
      }
      if (Input.GetKey(KeyCode.W))
      {
       MovementsFuntions.DiagonalActivated = true;
       Animations.StandingDiagonalTrue();
       ShoothingDiagonalFuntion();
      }
      else
      {
       MovementsFuntions.DiagonalActivated = false;
       Animations.StandingDiagonalFalse();
       Animations.ShothingStandingDiagonalFalse();        
      }
    }
    private void ShoothingDiagonalFuntion()
    {
      if (Input.GetKey(KeyCode.J) && Time.time > LastShot + 0.25f && !MovementsFuntions.LookingDownBool) //Si el ultimo disparo fue en el seg 3 le sumamos 0.25f, en el segundo 3.25 volve a disparar (Time.time" tiene que ser mas grande)
      {
       LastShot = Time.time;                                                                             //Almacenamos el tiempo en la variable cuando disparamos
       DifferentShot();
      }
      if ((Input.GetKey(KeyCode.J)) && Input.GetKey(KeyCode.W))
      {
       Animations.ShothingStandingDiagonalTrue();
      }
      else
      {
       Animations.ShothingStandingDiagonalFalse();
      }
    }
    public void ShotDown()
    {
      if (Input.GetKey(KeyCode.J) && Time.time > LastShot + 0.25f && transform.localScale == new Vector3(1, 1, 1))
      {
       Animations.DownShotTrue();
       LastShot = Time.time;
       DownShotRight();  
      }
      else
      {
      Animations.DownShotFalse();
      }
      if (Input.GetKey(KeyCode.J) && transform.localScale == new Vector3(-1, 1, 1) && Time.time > LastShot + 0.25)///////
      {            
       LastShot = Time.time;
       DownShotLeft();
      }
      if (Input.GetKey(KeyCode.J))
      {
       Animations.DownShotTrue();
      }
      else
      {  
       Animations.DownShotFalse();
      }
    }
    public void DownShotLeft()
    {
     Vector2 DiagonalLeftDirection = new Vector2(-0.218f, -0.155f);

     Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletSound);
     GameObject Bullet = Instantiate(VariantBullet, DownShotNegative.position, DownShotNegative.rotation);
     Bullet.GetComponent<Rigidbody2D>().AddForce(DiagonalLeftDirection * Velocity, ForceMode2D.Impulse);
    }

    private void DownShotRight()
    {
     DiagonalDirection = new Vector2(0.118f, -0.116f);

     Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletSound);
     GameObject Bullet = Instantiate(VariantBullet, DownShotPoint.position, DownShotPoint.rotation);
     Bullet.GetComponent<Rigidbody2D>().AddForce(DiagonalDirection * Velocity, ForceMode2D.Impulse);
       // Bullet.GetComponent<Rigidbody2D>().velocity = DiagonalDirection * Velocity;
    }
    private void DifferentShot()
    {
     Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletSound);
     GameObject Bullet = Instantiate(VariantBullet, FirePoint.position, FirePoint.transform.rotation);
     Bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * Velocity, ForceMode2D.Impulse);
    }
}
