using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] 
    private float _maxHp;
    private float _currentHp;
    
    public void OnDamage(float damage)
    {
        _currentHp -= damage;
        
        MainSceneUIManager.Instance.SetPlayerHp(_currentHp / _maxHp);
        
        if (_currentHp <= 0f)
        {
            PoolingParticle particle = PoolManager.Instance.Pop("Boom") as PoolingParticle;
            particle.SetPositionAndRotation(transform.position, Quaternion.identity);
            particle.Play();
            
            GameManager.Instance.IsGameOver = true;
        }
    }
}
