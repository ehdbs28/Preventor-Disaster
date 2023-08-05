using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private readonly int _isMoveToggle = Animator.StringToHash("is-move");
    private readonly int _onDie = Animator.StringToHash("on-die");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void IsMove(bool val)
    {
        _animator.SetBool(_isMoveToggle, val);
    }

    public void SetDie(bool val)
    {
        if (val)
        {
            _animator.SetTrigger(_onDie);
        }
        else
        {
            _animator.ResetTrigger(_onDie);
        }
    }
}
