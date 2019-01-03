using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour {
    public enum Direction
    {
        None, Center, Left, Right
    }

    private float forceForMoving = 108;
    private Direction inputDirection = Direction.None;
    private Direction movingDriection;
    private bool isMove = false;
    private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        Debug.Log(Vector3.left);
        Debug.Log(Vector3.right);
        rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetAxisRaw("Horizontal") == Vector3.left.x) {
            inputDirection = Direction.Left;
        } else if (Input.GetAxisRaw("Horizontal") == Vector3.right.x) {
            inputDirection = Direction.Right;
        } else if (Input.GetAxisRaw("Vertical") == Vector3.up.y 
                   || Input.GetAxisRaw("Vertical") == Vector3.down.y) {
            inputDirection = Direction.Center;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(rigidbody.velocity);
        if (inputDirection != movingDriection) {
            ClearForce();
            movingDriection = inputDirection;
            if (movingDriection == Direction.Left) {
                rigidbody.AddForce(Vector3.left * forceForMoving);
            } else if (movingDriection == Direction.Right) {
                rigidbody.AddForce(Vector3.right * forceForMoving);
            }
        }
    }

    void ClearForce() {
        if (movingDriection == Direction.Left) {
            rigidbody.AddForce(Vector3.right * forceForMoving);
        } else if (movingDriection == Direction.Right) {
            rigidbody.AddForce(Vector3.left * forceForMoving);
        }
    }

}
