using System.Collections;
using System.Collections.Generic;
using Assets.PixelHeroes.Scripts.CollectionScripts;
using UnityEngine;

public abstract class Calamity : PoolableMono
{
    [SerializeField] 
    protected float _damage;

    [SerializeField] 
    protected LayerMask _targetLayer;

    public abstract void OnCalamity();

    public void Attack(IDamageable other)
    {
        other.OnDamage(_damage);
    }
}
