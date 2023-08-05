using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float damage = 5;
    [SerializeField]
    private float moveSpeed = 10;

    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        // if (transform.position.magnitude > 1000.0f)
        // {
        //     Destroy(gameObject);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.GetModule<EnemyHealthModule>().OnDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
