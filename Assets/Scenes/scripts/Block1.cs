using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1 : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public BackgroundScroller backgroundscroller;
    public bool block;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        backgroundscroller = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        if (block) { anim = GetComponent<Animator>(); }
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = backgroundscroller.speed;
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < -22)
        {
            Destroy(gameObject);
        }

        if (block)
        {
            anim.SetBool("MakeBlockSmall", backgroundscroller.makeBlocksSmall);
        }


    }

  
}
