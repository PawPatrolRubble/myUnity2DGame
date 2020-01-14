using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed=3.0f;
    Vector2 movement=new Vector2();
    Rigidbody2D rigidbody2D;
    Animator animator;
    string animationState="AnimationState";

    enum CharStates
    {
        walkStart=1,
        Jump=2,
        other=3

    }

    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate() {
        MoveCharacter();

    }

    private void MoveCharacter(){
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rigidbody2D.velocity=movement*movementSpeed;
    }

    private void UpdateState(){
        if(movement.x>0){
            //move foreward
            animator.SetInteger(animationState,(int)CharStates.walkStart);

        }
        else if (movement.x<0){
            //move back
            animator.SetInteger(animationState,(int)CharStates.Jump);
        }
        
    }
}
