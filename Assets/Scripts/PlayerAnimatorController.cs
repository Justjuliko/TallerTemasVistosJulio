using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        IdleBreak,
        Walk,
        Run,
        Turn,
        Jump,
        Roll,
        PushObj,
        PushHeavyObj
    }
    private bool IsWalking()
    {
        return (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift));
    }
    private bool IsRunning()
    {
        return (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift));
    }
    private bool IsTurning()
    {
        return Input.GetKey(KeyCode.U);
    }
    private bool IsJumping()
    {
        return Input.GetKey(KeyCode.Space);
    }
    private bool IsRolling()
    {
        return Input.GetKey(KeyCode.V);
    }
    private bool IsPushingObj()
    {
        return Input.GetKey(KeyCode.F);
    }
    private bool IsPushingHeavyObj()
    {
        return Input.GetKey(KeyCode.G);
    }
    public Animator _CharacterAnimator;
    private PlayerState _currentState;
    void Start()
    {
        SetState(PlayerState.Idle);
    }
    void Update()
    {
        PlayerState newState = DeterminateState();
        if (newState != _currentState)
        {
            SetState(newState);
        }
    }
    private void SetState(PlayerState newState)
    {
        switch (_currentState)
        {
            case PlayerState.Idle:
                _CharacterAnimator.SetBool("idle", false); break;
            case PlayerState.IdleBreak:
                _CharacterAnimator.SetBool("idlebreak", false); break;
            case PlayerState.Walk:
                _CharacterAnimator.SetBool("walk", false); break;
            case PlayerState.Run:
                _CharacterAnimator.SetBool("run", false); break;
            case PlayerState.Turn:
                _CharacterAnimator.SetBool("turn", false); break;
            case PlayerState.Jump:
                _CharacterAnimator.SetBool("jump", false); break;
            case PlayerState.Roll:
                _CharacterAnimator.SetBool("roll", false); break;
            case PlayerState.PushObj:
                _CharacterAnimator.SetBool("pushobj", false); break;
            case PlayerState.PushHeavyObj:
                _CharacterAnimator.SetBool("pushheavyobj", false); break;
        }
        switch (newState)
        {
            case PlayerState.Idle:
                _CharacterAnimator.SetBool("idle", true); break;
            case PlayerState.IdleBreak:
                _CharacterAnimator.SetBool("idlebreak", true); break;
            case PlayerState.Walk:
                _CharacterAnimator.SetBool("walk", true); break;
            case PlayerState.Run:
                _CharacterAnimator.SetBool("run", true); break;
            case PlayerState.Turn:
                _CharacterAnimator.SetBool("turn", true); break;
            case PlayerState.Jump:
                _CharacterAnimator.SetBool("jump", true); break;
            case PlayerState.Roll:
                _CharacterAnimator.SetBool("roll", true); break;
            case PlayerState.PushObj:
                _CharacterAnimator.SetBool("pushobj", true); break;
            case PlayerState.PushHeavyObj:
                _CharacterAnimator.SetBool("pushheavyobj", true); break;
        }
        _currentState = newState;
    }
    private PlayerState DeterminateState()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            return PlayerState.IdleBreak;
        }
        else if (IsWalking())
        {
            return PlayerState.Walk;
        }
        else if (IsRunning())
        {
            return PlayerState.Run;
        }
        else if (IsTurning())
        {
            return PlayerState.Turn;
        }
        else if (IsJumping())
        {
            return PlayerState.Jump;
        }
        else if (IsRolling())
        {
            return PlayerState.Roll;
        }
        else if (IsPushingObj())
        {
            return PlayerState.PushObj;
        }
        else if (IsPushingHeavyObj())
        {
            return PlayerState.PushHeavyObj;
        }
        else
        {
            return PlayerState.Idle;
        }
    }
}
