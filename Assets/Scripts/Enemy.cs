using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{

    private float m_direction;
    public GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        m_direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded(m_xOffset)) //右脚离开地
        {
            m_direction = 1;
        }
        if (!IsGrounded(-m_xOffset))
        {
            m_direction = -1;
        }

        Move(m_direction, -1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Boomerang>() != null)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }
    }
}
