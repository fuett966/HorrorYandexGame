using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public float velocity;
    public bool isJump;
    public bool isRun;
    public bool onGround;
    public bool isWallSprint;
    public bool isClimbing;
    public bool isWallRunRight;
    public bool isAttack;
    public bool isDash;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isWallRunRight", isWallRunRight);
        _animator.SetFloat("velocity", velocity);
        _animator.SetBool("isWallSprint", isWallSprint);
        _animator.SetBool("isRun", isRun);
        _animator.SetBool("isJump", isJump);
        _animator.SetBool("onGround", onGround);
        _animator.SetBool("isClimbing", isClimbing);
        _animator.SetBool("isAttack", isAttack);   
    }

    public void PlayDashAnimation()
    {
        _animator.SetTrigger("Dash");
    }
    public void PlayJumpAnimation()
    {
        _animator.SetTrigger("Jump");
    }
    public void PlayDoubleJumpAnimation()
    {
        _animator.SetTrigger("DoubleJump");
    }
    public void PlayAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }
    public void EndDashAnimation()
    {
        _animator.SetTrigger("DashExit");
    } 
    public void PlayDanceAnimation()
    {
        _animator.SetTrigger("DanceStart");
    }
    public void EndDanceAnimation()
    {
        _animator.SetTrigger("DanceExit");
    } 
}
