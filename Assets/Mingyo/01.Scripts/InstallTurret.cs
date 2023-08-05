using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstallTurret : MonoBehaviour
{
    [SerializeField]
    private LayerMask TurretPosMask;

    [SerializeField]
    private GameObject _turret;

    private Vector3 _mousePos;

    private bool isWaiting = false;

    private SpriteRenderer _turretSpriteRenderer;

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

            RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero, TurretPosMask);

            if (hit.collider != null && !hit.transform.Find("Turret").gameObject.activeInHierarchy)
            {
                _turretSpriteRenderer.color = hit.collider.transform.Find("Turret").GetComponent<SpriteRenderer>().color;
            }
            else
            {
                _turretSpriteRenderer.color = Color.white;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if(hit.collider != null && !hit.transform.Find("Turret").gameObject.activeInHierarchy)
                {
                    hit.transform.Find("Turret").gameObject.SetActive(true);
                    hit.collider.GetComponent<SpriteRenderer>().enabled = false;
                    _turretSpriteRenderer.color = Color.white;

                    isWaiting = false;
                    _turret.gameObject.SetActive(false);
                    StopAllCoroutines();
                }
            }

            yield return null;
        }
    }
}
