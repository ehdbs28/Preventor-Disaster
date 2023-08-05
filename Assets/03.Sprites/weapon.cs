using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private float moveSpeed = 10;

    void Update()
    {
        // transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

}
