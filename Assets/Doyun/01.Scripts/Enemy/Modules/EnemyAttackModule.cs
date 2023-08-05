using System.Collections;
using UnityEngine;

public class EnemyAttackModule : EnemyModule
{
    [SerializeField] 
    private float _attackDamage;
    
    [SerializeField] 
    private float _attackDelay;

    [SerializeField] 
    private float _attackRadius = 3f;

    [SerializeField] 
    private LayerMask _targetLayer;
    
    private WaitUntil _canAttackUntil;
    private WaitForSeconds _attackDelayWFS;
    
    public override void AwakeModule()
    {
        _canAttackUntil = new WaitUntil(() => EnemyCon.ActionData.CanAttack);
        _attackDelayWFS = new WaitForSeconds(_attackDelay);

        StartCoroutine(AttackRoutine());
    }

    public override void UpdateModule()
    {
    }

    public override void FixedUpdateModule()
    {
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return _canAttackUntil;
            Attack();
            yield return _attackDelayWFS;
        }
    }

    private void Attack()
    {
        Vector3 attackDir = EnemyCon.ActionData.Dir;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position + attackDir, _attackRadius, _targetLayer);

        if (cols.Length > 0)
        {
            foreach (var col in cols)
            {
                if (col.TryGetComponent<IDamageable>(out IDamageable onDamage))
                {
                    onDamage.OnDamage(_attackDamage);
                }
            }
        }
    }
}
