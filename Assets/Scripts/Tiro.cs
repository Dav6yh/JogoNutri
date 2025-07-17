using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public int hit;
    private bool direcaoDir;
    private bool move = true;
    private Animator animator;



    // Update is called once per frame

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (!move)
        {
               
        }

        if (direcaoDir)
        {
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
            move = true;

        }
        else if (!direcaoDir)
        {
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            move = true;
        }

        //transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);

        StartCoroutine("DestroyAfter");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Chao"))
           // || other.gameObject.CompareTag("TriggerLeft") || other.gameObject.CompareTag("TriggerRight"))
        {
            StartCoroutine("DestroyShot");
        }
    }

    IEnumerator DestroyShot()
    {
        move = false;
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }

    public void ArrowRight()
    {
        direcaoDir = true;
    }

    public void ArrowLeft()
    {
        direcaoDir = false;
    }

    public int GetHit()
    {
        return hit;
    }
}