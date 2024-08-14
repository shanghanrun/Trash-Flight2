
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -6f;

    [SerializeField]
    private float hp =1f;

    public void SetMoveSpeed(float moveSpeed){  // 다른 클래스에서도 사용가능 public
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        // 특정 y좌표에 갔을 때, 인스턴스 제거하기  (-6 되면 사라지게)
        if(transform.position.y < minY){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { // isTrigger 충돌감지 자동실행됨
        if(other.gameObject.tag == "Weapon"){
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage; 
            if (hp<=0){
                Destroy(gameObject); 
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject); // 총알 사라짐
        }
    }
    
}
