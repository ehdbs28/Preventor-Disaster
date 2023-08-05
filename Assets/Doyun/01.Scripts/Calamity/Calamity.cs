using System.Collections;
using System.Collections.Generic;
using Assets.PixelHeroes.Scripts.CollectionScripts;
using UnityEngine;

public class Calamity : PoolableMono
{
    [SerializeField] 
    protected float _damage;

    [SerializeField] 
    protected LayerMask _targetLayer;

    [SerializeField] 
    private AudioClip _skillSound;

    public virtual void OnCalamity()
    {
        SoundManager.Instance.PlaySFX(_skillSound);
    }

    public void Attack(IDamageable other)
    {
        other.OnDamage(_damage);
    }

    public override void Init()
    {
        
    }
}
