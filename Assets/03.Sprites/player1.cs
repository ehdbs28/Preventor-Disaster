using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
	[SerializeField]
	private GameObject _bullet;
	public Transform pos;
	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private GameObject weapon;

	[SerializeField]
	private Transform shootTransform;

 	[SerializeField]
    private GameObject bulletPrefab;
	private bool isFacingRight = true;
    
	void Update(){
	
		float horizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = new Vector3(horizontalInput, VerticalInput, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 캐릭터 뒤집기
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
		
        //플레이어 총알 발사 
		  Vector2 Dir = (MousePos - PlayerPos);
 
        if (Input.GetMouseButtonDown(0) && n != -1) // SEMI AUTO
        {
            GameObject projectileObject = Instantiate(projectile[n], transform.position, Quaternion.Euler(0.0f, 0.0f, rotateDg));
            
            weapon = projectileObject.GetComponent<weapon>();
            weapon.Launch(Dir.normalized, 900);
        }
 
	}
	//반대쪽 방향으로 회전 
	private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
		/*자료
		// float horizontalInput = Input.GetAxisRaw("Horizontal");
		// float VerticalInput = Input.GetAxisRaw("Vertical");
		// Vector3 moveTo = new Vector3(horizontalInput,VerticalInput,0f);
		// transform.position +=moveTo * moveSpeed * Time.deltaTime;

		// // 캐릭터 뒤집기
        // if (horizontalInput > 0 && !isFacingRight)
        // {
        //     Flip();
		// 	// Shoot();
        // }
        // else if (horizontalInput < 0 && isFacingRight)
        // {
        //     Flip();
		// 	// Shoot();

        // }

		// //마우스 누르면 발사 
		// if (Input.GetMouseButton(0))
        // {
		// 	Vector3 screenMousePosition = Input.mousePosition; //마우스 위치 받기 

        // 	// 2. 스크린 좌표를 월드 좌표로 변환합니다.
        // 	Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
		// 	Vector3 mPosition = Input.mousePosition;

        //     Instantiate(weapon,mPosition, Quaternion.identity);
        // }
		// if (Input.GetMouseButtonDown(0) && n != -1) // SEMI AUTO
        // {
        //     GameObject projectileObject = Instantiate(projectile[n], transform.position, Quaternion.Euler(0.0f, 0.0f, rotateDg));
            
        //     projectileController = projectileObject.GetComponent<weapon >();
        //     projectileController.Launch(Dir.normalized, 900);
        // }
		// Player Shoot
        // Vector2 Dir = (MousePos - PlayerPos);
 
        // if (Input.GetMouseButtonDown(0) && n != -1) // SEMI AUTO
        // {
        //     GameObject projectileObject = Instantiate(projectile[n], transform.position, Quaternion.Euler(0.0f, 0.0f, rotateDg));
            
        //     projectileController = projectileObject.GetComponent<weapon>();
        //     projectileController.Launch(Dir.normalized, 900);
        // }
		// z 키 누르면 발사 
		// if(VerticalInput.GetKey(KeyCode.z))
		// {
		// 	Instantiate(_bullet,pos.position,shootTransform.rotation);
		// }*/
		// public float maxSpeed;
    //물리엔진으로 이동
    // Rigidbody2D rigid;

    //시작할 떄 한번만 실행되는 생명주기 Awake 에서 진행
    // void Awake()
    // {
    //     rigid = GetComponent<Rigidbody2D>();
    // }

    // void FixedUpdate()
    // {
    //     //캐릭터 움직임 컨트롤 
    //     float h = Input.GetAxisRaw("Horizontal");
    //     rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    //     // Limit the maximum horizontal speed of the player
    //     if (rigid.velocity.x > maxSpeed) // 오른쪽
    //         rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
    //     else if (rigid.velocity.x < -maxSpeed) // 왼쪽
    //         rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    // }
}
