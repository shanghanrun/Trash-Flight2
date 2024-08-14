
// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    

    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput,0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0,0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // } else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }
        
        // Debug.Log(Input.mousePosition);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        // Debug.Log(mousePos);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot(){
        // 10 -0 > 0.05 
        if(Time.time - lastShotTime > shootInterval){
            Instantiate(weapon, shootTransform.position, Quaternion.identity); //Quaternion 아무 회전 없음
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("적과 충돌");
            GameManager.instance.DecreaseHp();

            if(GameManager.instance.hp ==0){
                Destroy(gameObject);
            }

        } else if(other.gameObject.tag =="Coin"){
            Destroy(other.gameObject); // 코인제거
            GameManager.instance.IncreaseScore();

			// 예시: 코인 점수에 따라 HP 증가
			if (GameManager.instance.score % 10 == 0)
			{
				GameManager.instance.IncreaseHp();
			}

        }
    }
}
