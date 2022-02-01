using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsFuntions : MonoBehaviour
{   [Header("Floats")]
    public float Horizontal;
    [SerializeField]private float LastShot;
    [SerializeField]private float JumpForce =8.0f;
    [SerializeField]private float WalkingLastTime;
    [SerializeField]private float Speed ;

    [Header("Animator Var ")]
    [SerializeField]private Animator AnimatorVar;

    [Header("Bools")]
    public static bool DiagonalActivated;
    public static bool LookingDownBool;
    public static bool Ground;
    public static bool WalkingAnimation;
    public static bool DifferentiatingShots;

    [Header("Ints")]
    [SerializeField]private int CurrentEnergy = 100;
    [SerializeField]private int EnergyValue;

    [Header("Audio Clip")]
    [SerializeField]private AudioClip JumpSound;
    [SerializeField]private AudioSource Steps;

    [SerializeField]private Shooting CallShotFuntion;

    [SerializeField] private Rigidbody2D PlayerRigidBody;

    [SerializeField] private ScriptVar StartEnergy;
    public void Start()
    {
     CurrentEnergy = EnergyValue;
     StartEnergy.SetMaxHealth(CurrentEnergy);
    }
    private void Update()
    {
     MovementsCheck();
    }
    public void MovementsCheck()
    {
     Horizontal = Input.GetAxisRaw("Horizontal");
     AnimatorVar.SetBool("Running", Horizontal != 0.0f);

     if (Horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
     else if (Horizontal > 0) transform.localScale = new Vector3(1, 1, 1);

      if (Horizontal != 0.0) 
      {
         if (Input.GetKey(KeyCode.J) && Time.time > LastShot + .25f && !DiagonalActivated && !LookingDownBool)                                                 //Agregar Boolean para que no dispare cuando no queremso
         {               
          LastShot = Time.time;
          CallShotFuntion.Shot();
          DifferentiatingShots = true;
         }
         else if (Input.GetKey(KeyCode.J))                                                                           //Puedo ponerlo dentro de una funcion aparte
         {          
          Animations.RunShotFrontTrue();
         }
         else
         {         
          DifferentiatingShots = false; 
          Animations.RunShotFrontFalse();
         }           
      }
         else
         {
          DifferentiatingShots = false;
          Animations.RunShotFrontFalse();
         }
        
     PlayerRigidBody.velocity = new Vector2(Horizontal * Speed, PlayerRigidBody.velocity.y);

     CallShotFuntion.SideShots();

     JumpCheck();
     SoundFootSteps();
     LookinDown();
    }
   private void JumpCheck()
   {
     Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.red);

     if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))                                                         //Si el rayo invisible Colisiona es true , sino "False" 
     {
      Ground = true;
     }
     else
     {
      Ground = false;
     }
     if (Input.GetKeyDown(KeyCode.Space) && Ground)                                                                       //Salto Vetical/Diagonal 
     {         
      Jump();          
     }
    }
    private void LookinDown()
    {
      if (Input.GetKey(KeyCode.S))
      {
       MovementsFuntions.LookingDownBool = true;

       Animations.LookingDownTrue();          
       CallShotFuntion.ShotDown();
      }
      else
      {
       MovementsFuntions.LookingDownBool = false;
       Animations.LookingDownFalse();
       Animations.DownShotFalse();
      }
      if (Horizontal != 0.0 && Input.GetKey(KeyCode.S))
      {           
       Animations.RunningShotDownTrue();
      }
      else
      {          
      Animations.RunningShotDownFalse();
      }
    }
    private void Jump()
    {
     Animations.JumpTrue();
     Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
     PlayerRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
     if (Ground) Animations.JumpFalse();
    }
    private void SoundFootSteps()
    {
     if (WalkingAnimation = Horizontal != 0.0 && Time.time > WalkingLastTime + 0.3    )
     WalkingLastTime = Time.time;
     if (Ground) WalkingSound();      
    }
    private void WalkingSound()
    {
     Steps.Play();
    }
}





