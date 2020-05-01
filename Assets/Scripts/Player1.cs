using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    #region Variables
    [Header("Player")]
    public Rigidbody2D rb;
    public int speed = 5;
    public int jumpSpeed = 15;
    [Header("Menu")]
    public CanvasGroup pauseMenu;
    public bool isPaused = false;
    public bool fadingIn;
    public bool fadingOut;
    #endregion
    void Start()
    {
        //assigns the player's rigidbody to rb
        rb = GetComponent<Rigidbody2D>();
        //stops time while the start game menu is active
        setTimeScale(0);
    }

    public void Update()
    {
        #region Jumping
        //makes the player jump when the jump key is pressed
        if (Input.GetKeyDown(KeyBinds.keys["Jump"]))
        {
            rb.velocity = new Vector2(0, 1) * jumpSpeed;
        }
        //lets the player hover in the air while jumping
        if (Input.GetKey(KeyBinds.keys["Jump"]))
        {
            rb.gravityScale = 3;
        }
        #endregion
        #region Pausing
        //when escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if the game is not paused, pause it
            if(!isPaused)
            {
                setTimeScale(0);
                isPaused = true;
                pauseMenu.alpha = 0;
                pauseMenu.gameObject.SetActive(true);
                fadingIn = true;
            }
            //if the game is paused, unpause it
            else if(isPaused)
            {
                setTimeScale(1);
                isPaused = false;
                pauseMenu.alpha = 1;
                fadingOut = true;
            }
        }
        //allows for the fading in and out of the pause menu
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
        #endregion
    }
    public void FixedUpdate()
    {
        //controls movement on x axis
        if (Input.GetKey(KeyBinds.keys["Left"]))
        {
            transform.Translate((-speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyBinds.keys["Right"]))
        {
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }

        //allows for fast falling
        if (Input.GetKey(KeyBinds.keys["Fall"]))
        {
            rb.velocity = new Vector2(0, -1) * 10;
        }
    }
    //function that allows for time.timescale to be changed easily
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