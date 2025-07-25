using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int vida = 3;
    [SerializeField] private float dano;
    [SerializeField] private float velocidadeAndar;
    // [SerializeField] private float velocidadeRun;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float moveH;
    [SerializeField] private bool noPiso = true;
    [SerializeField] private int pontosTotais = 0;
    [SerializeField] private GameObject tiroPreFab;
    [SerializeField] private GameObject mira;
    [SerializeField] private float forcaTiro;
    [SerializeField] private AudioClip tiro;
    [SerializeField] private AudioClip jump;
    private float velocidadeAtual;
    private bool estaVivo = true;
    private TextMeshProUGUI textoPontos;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private bool direcao;
    private bool shot;
    private bool atirandoDir;
    private Audio audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GameObject.Find("AudioSource").GetComponent<Audio>();

        //textoPontos = GameObject.Find("Point").GetComponent<TextMeshProUGUI>();
        //textoPontos.text = "0";
    }

    void Update()
    {
        Andar();
        Pular();
        ArrowShot();
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
            atirandoDir = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
            atirandoDir = false;
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
            audioSource.TocarSom(jump);
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

    private void LevarDano()
    {
        if (vida > 0)
        {
            --vida;
            animator.SetTrigger("Hurt");
        }
        else if (vida <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        
       StartCoroutine("Morrendo");
        
    }

    IEnumerator Morrendo()
    {
        animator.SetBool("EstaVivo", false);
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MenuPrincipal");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noPiso = true;
            animator.SetBool("EstaChao", true);
            //animator.SetFloat("ValorPulo", 0);
        }

        if (collision.gameObject.CompareTag("Fatal") || collision.gameObject.CompareTag("Inimigo"))
        {
            LevarDano();
        }
    }
    private void ArrowShot()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (!shot)
            {
                audioSource.TocarSom(tiro);
                if (atirandoDir)
                {
                    Instantiate(tiroPreFab, mira.transform.position, Quaternion.identity).GetComponent<Arrow>().ArrowRight();
                }
                else
                {
                    Instantiate(tiroPreFab, mira.transform.position, Quaternion.Euler(0, 180f, 0)).GetComponent<Arrow>().ArrowLeft();
                }

                StartCoroutine("DestroyArrow");
            }
        }
    }


    IEnumerator DestroyArrow()
    {
        shot = true;
        yield return new WaitForSeconds(1.0f);
        shot = false;
    }



    private void Especial()
    {

    }


}
