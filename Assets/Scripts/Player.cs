using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    [SerializeField] private float dano;
    [SerializeField] private float velocidadeAndar;
    // [SerializeField] private float velocidadeRun;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float moveH;
    [SerializeField] private bool noPiso = true;
    [SerializeField] private int pontosTotais = 0;
    [SerializeField] private GameObject tiroPreFab;
    [SerializeField] private GameObject mira;
    [SerializeField] private int forcaTiro;
    private float velocidadeAtual;
    private bool estaVivo = true;
    private TextMeshProUGUI textoPontos;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //textoPontos = GameObject.Find("Point").GetComponent<TextMeshProUGUI>();
        //textoPontos.text = "0";
    }

    void Update()
    {
        Andar();
        Pular();
        Atacar();
        //Correr();
    }

    private void Andar()
    {

        moveH = Input.GetAxis("Horizontal"); 
        transform.position += new Vector3(moveH * Time.deltaTime * velocidadeAndar, 0, 0);
        AnimaAndar();
        if (Input.GetKey(KeyCode.D))
        {
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("Andando", false);
            animator.SetBool("Parado", true);
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    animator.SetBool("PulandoAr", true);
        //    animator.SetBool("Andando", true);
            
        //}
    }

    private void Correr()
    {
      
    }
    private void AnimaAndar()
    {
        if (moveH > 0)
        {
            animator.SetTrigger("Andar");
            animator.SetBool("Andando", true);
            animator.SetBool("Parado", false);
        }
        else if (moveH < 0)
        {
            animator.SetTrigger("Andar");
            animator.SetBool("Andando", true);
            animator.SetBool("Parado", false);
        }
        else
        {
            animator.SetBool("Andando", false);
            animator.SetBool("Parado", true);
        }
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noPiso)
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noPiso = false;
            animator.SetBool("EstaChao", false);
            animator.SetTrigger("Pular");
        }

        //if (Input.GetKey(KeyCode.D) && noPiso == false)
        //{
        //    animator.SetBool("EstaChao", false);
        //    animator.SetTrigger("Pular");
        //    animator.SetBool("PulandoAr", true);
            
        //}
        //else if (Input.GetKey(KeyCode.A) && noPiso == false)
        //{
        //    animator.SetBool("EstaChao", false);
        //    animator.SetTrigger("Pular");
        //    animator.SetBool("PulandoAr", true);

        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noPiso = true;
            animator.SetBool("EstaChao", true);
            animator.SetFloat("ValorPulo", 0);
        }
    }

    private void Atacar()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Atirar());
            animator.SetTrigger("Atirar");
        }
    }

    IEnumerator Atirar()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject tiro =  Instantiate(tiroPreFab, mira.transform.position, mira.transform.rotation);
        tiro.transform.rotation *= Quaternion.Euler(0, 0, 0);
        Rigidbody rbTiro = tiro.GetComponent<Rigidbody>();
        rbTiro.AddForce(mira.transform.forward * forcaTiro, ForceMode.Impulse);

    }

    private void Especial()
    {

    }


}
