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
        _animator.SetBool("onGround", onGround);//Motor.GroundingStatus.IsStableOnGround
        _animator.SetBool("isClimbing", isClimbing);
    }
}
