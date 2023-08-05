using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationModule : EnemyModule
{
    private Animator _animator;

    private readonly int IsHeavy = Animator.StringToHash("is-heavy");
    private readonly int IsRanger = Animator.StringToHash("is-ranger");
    private readonly int IsSpeedy = Animator.StringToHash("is-speedy");

    // private readonly int IsDieTrigger = Animator.StringToHash("is-die");
    
    public override void AwakeModule()
    {
        _animator = EnemyCon.GetComponent<Animator>();
        
        switch (EnemyCon.EnemyType)
        {
            case EnemyType.Heavy:
                _animator.SetBool(IsHeavy, true);
                break;
            case EnemyType.Speedy:
                _animator.SetBool(IsSpeedy, true);
                break;
            case EnemyType.Ranger:
                _animator.SetBool(IsRanger, true);
                break;
        }
    }

    public override void UpdateModule()
    {
    }

    public override void FixedUpdateModule()
    {
    }
}
