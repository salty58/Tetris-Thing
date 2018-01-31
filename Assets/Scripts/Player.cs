using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;

    public GameObject check;

    bool isOnGround = false;

    Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, myRigidBody.velocity.y);
        }
        else
        {
            myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            isOnGround = false;
        }
	}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Floor")
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Portal1")
        {
            Debug.Log("In portal now");
            check.SetActive(false);
        }
        if (collisionInfo.gameObject.tag == "Death")
        {
            transform.position = new Vector2(-25.35f, -6.47f);
        }
    }
}
