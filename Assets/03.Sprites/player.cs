/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public float maxSpeed;
	//public Vector2 inputVec;
	//물리엔진으로 이동
	Rigidbody2D rigid;

	//시작할 떄 한번만 실행되는 생명주기 Awake 에서 진행
	void Awake()
	{
		//Rigidbody2D 이 rigid 에 들어간다. 
		
		rigid = GetComponent<Rigidbody2D>();
	}
	// }
	// void Update(){
	// 	inputVec.x = Input.GetAxis("Horizontal");
	// 	inputVec.y = Input.GetAxis("Vertical");
	// }
	void FixedUpdate(){
		// //1. 힘을 준다. 
		// rigid.AddForce(inputVec);
		// //2. 속도 제어 
		// rigid.velocity = inputVec; //속도를 직접 제어하겠다. 
		//3. 위치 이동 
		//캐릭터 움직임 컨트롤 
		float h = Input.GetAxisRaw("Horizontal");
		rigid.AddForce(Vector2.right * h,ForceMode2D.Impulse);
		
		if(rigid.velocity.x > maxSpeed) //오른쪽 
			rigid.velocity = new Vector2(maxSpeed,rigid.velocity.y);
		else if(rigid.velocity.x<maxSpeed*(-1)) //왼쪽
			rigid.velocity = new Vector2(maxSpeed*(-1),rigid.velocity.y);

	}
	
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;
	private bool isFacingRight = true;
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
	void Update(){

		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float VerticalInput = Input.GetAxisRaw("Vertical");
		Vector3 moveTo = new Vector3(horizontalInput,VerticalInput,0f);
		transform.position +=moveTo * moveSpeed * Time.deltaTime;

		// 캐릭터 뒤집기
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

	}
	private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
