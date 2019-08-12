using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour {

    Rigidbody2D rbody2D;
	// Use this for initialization
	void Start () {
        rbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) MoveLeftFaster();
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)) MoveLeftSlower();
            else MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) MoveRightFaster();
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)) MoveRightSlower();
            else MoveRight();
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) MoveLeftFaster();
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) MoveLeftSlower();
            else MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) MoveRightFaster();
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) MoveRightSlower();
            else MoveRight();
        }
        else
        {
            rbody2D.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 350.0f) transform.position = new Vector3(350.0f, transform.position.y, transform.position.z);
        if (transform.position.x < -350.0f) transform.position = new Vector3(-350.0f, transform.position.y, transform.position.z);
    }

    public void MoveLeft()
    {
        rbody2D.velocity = new Vector2(-500.0f, 0.0f);
    }

    public void MoveLeftFaster()
    {
        rbody2D.velocity = new Vector2(-1500.0f, 0.0f);
    }

    public void MoveLeftSlower()
    {
        rbody2D.velocity = new Vector2(-200.0f, 0.0f);
    }

    public void MoveRight()
    {
        rbody2D.velocity = new Vector2(500.0f, 0.0f);
    }

    public void MoveRightFaster()
    {
        rbody2D.velocity = new Vector2(1500.0f, 0.0f);
    }

    public void MoveRightSlower()
    {
        rbody2D.velocity = new Vector2(-200.0f, 0.0f);
    }
}
