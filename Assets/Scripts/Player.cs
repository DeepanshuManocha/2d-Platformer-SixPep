﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private Rigidbody2D rb;
    [SerializeField] private float speed, jumpForce;
    public GameObject gameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log(isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("endPoint"))
        {
            gameOver = Instantiate(gameOver, new Vector2(0,0), Quaternion.identity) as GameObject;
            Time.timeScale = 0;
        }

        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }

    }
    

    private void PlayerControl()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        transform.Translate(new Vector2(horizontal * speed, rb.velocity.y) * Time.deltaTime);
        
    }

    


    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
}
