using System;
using UnityEngine;

public class EnemyHealthModule : EnemyModule, IDamageable
{
    [SerializeField] 
    private float _initMaxHp;

    private float _maxHp;
    private float _currentHp;

    public event Action OnDieEvent = null;
    
    public override void AwakeModule()
    {
        _maxHp = _initMaxHp + (Mathf.Pow(2, PhaseManager.Instance.CurPhase) / 2 - 2);
        _currentHp = _maxHp;
    }

    public override void UpdateModule()
    {
    }

    public override void FixedUpdateModule()
    {
    }

    public void OnDamage(float damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0f)
        {
            EnemyCon.IsAlive = false;
            PoolingParticle boom = PoolManager.Instance.Pop("Boom") as PoolingParticle;
            boom.SetPositionAndRotation(transform.position, Quaternion.identity);
            boom.Play();
            OnDieEvent?.Invoke();
            PoolManager.Instance.Push(EnemyCon);
        }
    }
}