using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    public int jumpSpeed = 15;
    public CanvasGroup pauseMenu;
    public bool isPaused = false;
    public bool fadingIn;
    public bool fadingOut;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setTimeScale(0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyBinds.keys["Jump"]))
        {
            rb.velocity = new Vector2(0, 1) * jumpSpeed;
        }
        if (Input.GetKey(KeyBinds.keys["Jump"]))
        {
            rb.gravityScale = 3;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                setTimeScale(0);
                isPaused = true;
                pauseMenu.alpha = 0;
                pauseMenu.gameObject.SetActive(true);
                fadingIn = true;
            }
            else if(isPaused)
            {
                setTimeScale(1);
                isPaused = false;
                pauseMenu.alpha = 1;
                fadingOut = true;
            }
        }
        if(fadingIn)
        {
            pauseMenu.alpha += Time.unscaledDeltaTime;
            if(pauseMenu.alpha == 1)
            {
                fadingIn = false;
            }
        }
        if(fadingOut)
        {
            pauseMenu.alpha -= Time.unscaledDeltaTime;
            if(pauseMenu.alpha == 0)
            {
                fadingOut = false;
                pauseMenu.gameObject.SetActive(false);
            }
        }
    }
    public void FixedUpdate()
    {
        //Horizontal movement
        if (Input.GetKey(KeyBinds.keys["Left"]))
        {
            transform.Translate((-speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyBinds.keys["Right"]))
        {
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }

        //Fast down
        if (Input.GetKey(KeyBinds.keys["Fall"]))
        {
            rb.velocity = new Vector2(0, -1) * 10;
        }
    }
    public void setTimeScale(int type)
    {
        switch (type)
        {
            case 0:
                Time.timeScale = 0;
                break;
            case 1:
                Time.timeScale = 1;
                break;
        }
    }
 }