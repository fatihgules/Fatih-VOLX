using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     #region Singleton
     public static PlayerController Instance {get;  set;}
     #endregion
    public VariableJoystick variableJoystick;
    public CharacterController characterController;
    public Animator PlayerAnim;
    
    public float Speed;
    public float TurnSmooth;
    float TurnSmoothVelocity;

   void Awake()
   {
    Instance=this;
   }

    void Start()
    {
         //Upgrade Data Check
         Speed=PlayerPrefs.GetFloat("Speed");
     
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
      
        
    
         float Horizontal = variableJoystick.Horizontal;
         float Vertical =variableJoystick.Vertical;

         Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

         if (direction.magnitude >= 0.1f)
         {

             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmooth);
             transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

             characterController.Move(direction * Speed * Time.deltaTime);
             PlayerAnim.SetBool("Walking", true);

         }

         else
         {
             PlayerAnim.SetBool("Walking", false);
         }
     
    
    }

  


   



}

