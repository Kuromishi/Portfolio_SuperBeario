using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public float m_moveSpeed;
    public float m_rayLength;
    public float m_xOffset;
         
    protected Rigidbody2D rb;//the third type variable:Protected !!! Can only be used by myself & my family
    protected Animator anim;

    //static: across the entire game. only give one response.全局变量

    private SpriteRenderer sr;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Move(float direction, int isFlip) //direction=xInput;   Horizontal
    {
        if (direction < 0)
        {
            sr.flipX = true;  //翻转
           // this.gameObject.transform.localScale = new Vector3(-3.168197f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }
        if(direction > 0)
        {
            sr.flipX = false;
           // this.gameObject.transform.localScale = new Vector3(3.168197f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

        }

        rb.velocity = new Vector2(isFlip*direction * m_moveSpeed , rb.velocity.y);  //velocity, just change position, addforce

        anim.SetFloat("Speed", Mathf.Abs(direction)); //绝对值。动起来，direction大于0，就idle to walk； 不动，direction=0，就walk to idle。

    }

    protected bool IsGrounded(float offsetX)
    {
        //Define the starting point of the ray
        Vector2 rayStart = new Vector2(transform.position.x + offsetX, transform.position.y); //transform.position.y - offsetY 让射线的起点y往下一点，防止和自己碰撞体碰撞
        //在sprite中将pivot设置为bottom center就不用yoffset了

        //Draw a ray in Scene view so we can see how long and where it starts
        Debug.DrawRay(rayStart, Vector2.down * m_rayLength,Color.red); //check what the ray really looks like

        RaycastHit2D ray = Physics2D.Raycast(rayStart, Vector2.down, m_rayLength);

        if(ray.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
