using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangHit : MonoBehaviour
{
    public GameObject Boomerang;
    public GameObject bear;
    private float offSet=0.6f;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            direction = bear.GetComponent<SpriteRenderer>().flipX == true ? -1 : 1;
            GameObject boom= Instantiate(Boomerang, new Vector3(transform.position.x+direction*offSet,transform.position.y,transform.position.z), transform.rotation);
            boom.GetComponent<Boomerang>().direction =direction ;
        }
    }

}
