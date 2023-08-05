using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float cooltime;
    private float curtime;

    private bool canAttack = true;

    private Camera mainCam;

    [SerializeField] private AudioClip shotClip;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttack){
            if(Input.GetMouseButton(0))
            {
                SoundManager.Instance.PlaySFX(shotClip);
                
                CameraManager.Instance.ShakeCam(0.3f, cooltime);
                
                curtime = 0f;
                canAttack = false;
                Vector3 mousepos = mainCam.ScreenToWorldPoint(Input.mousePosition);

                Vector3 dir = (mousepos - transform.position).normalized;

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                
                Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

            }
        }
        else
        {
            curtime += Time.deltaTime;

            if (curtime >= cooltime)
            {
                canAttack = true;
            }
        }
    }
}
