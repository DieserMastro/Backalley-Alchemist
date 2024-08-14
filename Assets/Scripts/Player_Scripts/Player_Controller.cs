using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //System Data
    private Rigidbody2D rb;
    private Vector2 pos;


    //Gameplay Data
    [SerializeField]
    protected float moveSpeed;
    private Vector2 moveVec = new Vector2(0,0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        
        pos = rb.transform.position;

    }
    void CheckMovement()
    {
        //Movement... There has to be a better/cleaner way...
        if (Input.GetKey(KeyCode.W))
        {
            moveVec.y = 1f;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVec.y = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVec.x = -1f;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveVec.x = 0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVec.y = -1f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveVec.y = 0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVec.x = 1f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveVec.x = 0f;
        }
        rb.transform.position = pos + (moveVec * moveSpeed * Time.deltaTime);
    }
}

