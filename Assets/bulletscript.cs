using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public LayerMask isLayer;
    void Start()
    {
        Invoke("DestroyBullet",2);
    }

    // Update is called once per frame
    void Update()
    {
        // //주인공의 공격이 적에 부딪히면 발사체가 사라짐 
        // RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, speed); //직선을 쏴서 경로의 물체들과 충돌을 boolean값으로 반환
        // //ray 가 특정 레이어에 부딪히면 함수 실행 
        // if(ray.collider != null)
        // {
        //     //설정해둔 태그가 Enemy인 경우 true
        //     if(ray.collider.tag == "Enemy")
        //     {
        //         Debug.Log("맞음"); //적 캐릭터에 맞으면 로그 찍힘 
        //     }
        //     DestroyBullet();
        // }
        // // 수정된 부분:
        // if (transform.rotation.y == 0)
        // {
            transform.Translate(Vector2.right * Time.deltaTime);
        // }
        // else
        // {
        //     transform.Translate(transform.right * speed * Time.deltaTime); // 두 번째 '*'가 제거되어 'speed'로 수정
        // }
    }
    void DestroyBullet(){
        Destroy(gameObject);
    }
}
