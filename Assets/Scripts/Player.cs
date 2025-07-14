using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    [SerializeField] private float dano;
    [SerializeField] private float velocidadeAndar;
    [SerializeField] private float velocidadeRun;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float moveH;
    [SerializeField] private bool noPiso = true;
    [SerializeField] private int pontosTotais = 0;
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
        textoPontos = GameObject.Find("Point").GetComponent<TextMeshProUGUI>();
        textoPontos.text = "0";
    }

    void Update()
    {
        Andar();
        Pular();
        Correr();
    }

    private void Andar()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveH = Input.GetAxis("Horizontal");
            transform.position += new Vector3(moveH * Time.deltaTime * velocidadeAtual, 0, 0);
            AnimaAndar();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveH = Input.GetAxis("Horizontal");
            transform.position += new Vector3(moveH * Time.deltaTime * velocidadeAtual, 0, 0);
            AnimaAndar();
        }
    }

    private void Correr()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = velocidadeRun;
            animator.SetBool("Andando", true);
            animator.SetBool("Correndo", true);
            animator.SetTrigger("Corre");
        }
        else
        {
            velocidadeAtual = velocidadeAndar;
            animator.SetBool("Andando", true);
            animator.SetBool("Correndo", true);
        }
    }
    private void AnimaAndar()
    {
        if (moveH > 0)
        {
            sprite.flipX = false;
            animator.SetBool("Andando", true);
            animator.SetTrigger("Andar");
            animator.SetBool("Correndo", false);
            animator.SetBool("EstaChao", true);
        }
        else if (moveH < 0)
        {
            sprite.flipX = true;
            animator.SetBool("Andando", true);
            animator.SetTrigger("Andar");
            animator.SetBool("Correndo", false);
            animator.SetBool("EstaChao", true);
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
    }

    private void Atacar()
    {

    }
}
