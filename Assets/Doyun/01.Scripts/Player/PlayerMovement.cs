using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimator _anim;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private AudioClip stepClip;

    private float stepCool = 0.3f;
    private float cur = 0;

    private bool isStep = true;

    private void Awake()
    {
        _anim = GetComponent<PlayerAnimator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        _anim.IsMove(dir.magnitude > 0);

        if (dir.magnitude > 0)
        {
            if (isStep)
            {
                isStep = false;
                cur = 0f;
                SoundManager.Instance.PlaySFX(stepClip);
            }
            else
            {
                cur += Time.deltaTime;

                if (cur >= stepCool)
                {
                    isStep = true;
                }
            }
        }

        if (dir.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (dir.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        transform.position += dir * 10 * Time.deltaTime;
    }
}
