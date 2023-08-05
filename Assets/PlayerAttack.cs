using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    

    // Update is called once per frame
    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition )-transform.position;
        float z = Mathf.Atan2(len.y,len.x) * Mathf.Rad2Deg;
        transform rotation = Quaternion.Euler(0,0,z);
        if(curtime <=0){
            if(Input.GetKey(KeyCode.Z)){
                Instantiate(bullet, pos.position, transform.rotation);

            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}