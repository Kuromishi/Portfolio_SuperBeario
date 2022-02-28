using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed;
    public int damage;
    public float rotateSpeed;
    public float tuning;

    private Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform boomerangTransform;
    private Vector2 startSpeed;
    public int direction;

    public AudioSource enemyDieSFX;
    public AudioSource boomerangSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        playerTransform = GameObject.FindGameObjectWithTag("Beario").GetComponent<Transform>();
        rb2d.velocity = direction * playerTransform.right * speed;
        startSpeed = rb2d.velocity;
        //Debug.Log(direction);
        boomerangTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y+2.5f, tuning);
        transform.position = new Vector3(transform.position.x, y, 0.0f);
        rb2d.velocity =rb2d.velocity - startSpeed * Time.deltaTime;
        if(Mathf.Abs(transform.position.x - playerTransform.position.x)<0.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            enemyDieSFX.Play();
            boomerangSFX.Play();
        }
      }

}
