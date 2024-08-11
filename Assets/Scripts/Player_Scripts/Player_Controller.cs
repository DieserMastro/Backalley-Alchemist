using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 pos;

    [SerializeField]
    protected float moveSpeed;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.position = new Vector3(pos.x, pos.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position = new Vector3(pos.x - moveSpeed * Time.deltaTime, pos.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.position = new Vector3(pos.x, pos.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position = new Vector3(pos.x + moveSpeed * Time.deltaTime, pos.y);
        }

        pos = rb.transform.position;
    }

}
