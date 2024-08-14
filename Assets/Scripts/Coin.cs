
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private float minY = -6f;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    void Jump(){
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(4f,8f); // 4.0, 4.12, 5.6..
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f,2f); // 좌우로도 가능

        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< minY){
            Destroy(gameObject);
        }
    }
}
