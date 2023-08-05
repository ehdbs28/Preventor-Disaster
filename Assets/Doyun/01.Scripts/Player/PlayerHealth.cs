using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] 
    private float _maxHp;
    private float _currentHp;

    private PlayerAnimator _anim;

    private void Awake()
    {
        _anim = GetComponent<PlayerAnimator>();
        _currentHp = _maxHp;
    }

    public void OnDamage(float damage)
    {
        _currentHp -= damage;
        
        MainSceneUIManager.Instance.SetPlayerHp(_currentHp / _maxHp);
        
        if (_currentHp <= 0f)
        {
            PoolingParticle particle = PoolManager.Instance.Pop("Boom") as PoolingParticle;
            particle.SetPositionAndRotation(transform.position, Quaternion.identity);
            particle.Play();
            
            _anim.SetDie(true);
            
            GameManager.Instance.IsGameOver = true;
        }
    }
}
