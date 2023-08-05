using System;
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

    [SerializeField] 
    private AudioClip _attackClip;
    
    private WaitForSeconds _attackDelayWFS;

    private Vector3 _attackDir;
    private Collider2D[] _cols = { };
    
    public override void AwakeModule()
    {
        _attackDelayWFS = new WaitForSeconds(_attackDelay);

        StartCoroutine(AttackRoutine());
    }

    public override void UpdateModule()
    {
        _attackDir = EnemyCon.ActionData.Dir;
        _cols = Physics2D.OverlapCircleAll(EnemyCon.transform.position + _attackDir, _attackRadius, _targetLayer);
    }

    public override void FixedUpdateModule()
    {
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            Attack();
            yield return _attackDelayWFS;
        }
    }

    private void Attack()
    {
        if (_cols.Length <= 0)
            return;
        
        SoundManager.Instance.PlaySFX(_attackClip);
        
        PoolingParticle particle = PoolManager.Instance.Pop("Slash") as PoolingParticle;

        Vector3 pos = EnemyCon.transform.position + _attackDir;

        float angle = Mathf.Atan2(_attackDir.y, _attackDir.x) * Mathf.Rad2Deg;
        particle.SetPositionAndRotation(pos, Quaternion.AngleAxis(angle, Vector3.forward));
        
        foreach (var col in _cols)
        {
            if (col.TryGetComponent<IDamageable>(out IDamageable onDamage))
            {
                onDamage.OnDamage(_attackDamage);
            }
        }
    }
}
