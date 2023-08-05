using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float range = 5;

    public float Damage;

    private LayerMask _enemyLayer = 1 << 16;

    [SerializeField] private float speed;

    Vector3 dir;

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, _enemyLayer);

        if(hit != null)
        {
            dir = hit.transform.position - transform.position;

            transform.position += dir.normalized * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.GetModule<EnemyHealthModule>().OnDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
