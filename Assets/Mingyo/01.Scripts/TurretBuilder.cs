using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    [SerializeField]
    private LayerMask TurretPosMask;

    [SerializeField]
    private GameObject _turret;

    private Vector3 _mousePos;

    private bool isWaiting = false;

    private SpriteRenderer _turretSpriteRenderer;

    [SerializeField]
    AudioClip _audioClip;

    private void Awake()
    {
        _turretSpriteRenderer = transform.Find("Turret").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (isWaiting)
            {
                _turret.gameObject.SetActive(false);
                isWaiting = false;
                StopAllCoroutines();
            }
            else
            {
                isWaiting = true;
                _turret.gameObject.SetActive(true);
                StartCoroutine(WaitingInstall());
            }
        }
        
    }

    private IEnumerator WaitingInstall()
    {
        while(true)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _mousePos += new Vector3(0, 0, 10);

            _turret.transform.position = _mousePos;

            RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero,0, TurretPosMask);

            if (hit.collider != null && !hit.transform.Find("Turret").gameObject.activeInHierarchy)
            {
                Transform targetTurret = hit.collider.transform.Find("Turret");

                _turretSpriteRenderer.sprite = targetTurret.GetComponent<SpriteRenderer>().sprite;
                _turret.transform.localScale = targetTurret.transform.localScale;
            }
            else
            {
                _turret.transform.localScale = new Vector2(0.1f,0.1f);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if(hit.collider != null && !hit.transform.Find("Turret").gameObject.activeInHierarchy)
                {
                    hit.transform.Find("Turret").gameObject.SetActive(true);
                    hit.collider.GetComponent<SpriteRenderer>().enabled = false;

                    SoundManager.Instance.PlaySFX(_audioClip);

                    isWaiting = false;
                    _turret.gameObject.SetActive(false);
                    StopAllCoroutines();
                }
            }

            yield return null;
        }
    }
}
