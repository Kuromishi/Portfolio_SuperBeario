using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine.UI;

public class Character : BaseUnit
{
    public AudioSource jumpSFX;
    public float jumpHeight;
    private float xInput;
    public GameObject bloodEffect;
    public AudioSource AppleSFX;

    public GameObject WinImage;
    public GameObject LoseImage;
    private bool isPausedForWin;
    private bool isPausedForLose;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        WinImage.SetActive(false);
        LoseImage.SetActive(false);
        isPausedForWin = false;
        isPausedForLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPausedForWin && !isPausedForLose)
        {
            xInput = Input.GetAxis("Horizontal");
            Move(xInput, 1);

            if (IsGrounded(m_xOffset) || IsGrounded(-m_xOffset)) //设置两个射线，x所在位置往左往右
            {
                anim.SetBool("Grounded", true);
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    //anim.SetTrigger("Jump");
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight); //只改变y轴
                                                                          // anim.SetBool("Grounded", false);
                    jumpSFX.Play();

                }
                //else
                //anim.SetBool("Grounded", IsGrounded(m_xOffset)|| IsGrounded(-m_xOffset));
            }
            else
                anim.SetBool("Grounded", false);
        }
           

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>()!=null)
        {

            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            LoseGame();
        }

        if(collision.gameObject.GetComponent<MovingPlatform>()!=null)
        {
            transform.SetParent(collision.transform);//熊跳到平台时，跟着平台动
           
        }
        if (collision.gameObject.GetComponent<flag>() != null)
        {
            WinGame();

        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.SetParent(null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Thorn>() != null)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            LoseGame();
        }
        if (collision.gameObject.GetComponent<pickup>() != null)
        {
            AppleSFX.Play();
        }
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            LoseGame();
        }
    }


    public void WinGame()
    {
        if (!WinImage.activeSelf)
        {
            WinImage.SetActive(true);
            //Time.timeScale = 0;
            isPausedForWin = true;
           
        }
    }

    public void LoseGame()
    {

        if (!LoseImage.activeSelf)
        {
            LoseImage.SetActive(true);
            //Time.timeScale = 0;
            isPausedForLose = true;

        }
    }
}
