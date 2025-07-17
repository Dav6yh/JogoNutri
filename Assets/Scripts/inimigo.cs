using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    [SerializeField] private int dir = 1;
    [SerializeField] private float speed;
    private SpriteRenderer sprite;
    private Animator animator;
    private Audio audioSource;
    [SerializeField] private AudioClip idle;
    [SerializeField] private AudioClip morrer;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GameObject.Find("AudioSource").GetComponent<Audio>();

    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        audioSource.TocarSom(idle);
    }

    private void Andar()
    {
        
        transform.position += new Vector3(dir * speed * Time.deltaTime,0,0);
    }

    private void patrulha()
    {
        if (dir == 1)
        {
            dir = -1;
            sprite.flipX = true;
        }
        else
        {
            dir = 1;
            sprite.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Direita"))
        {
            
            patrulha();
            
        }
       else if (collision.gameObject.CompareTag("Esquerda"))
        {

            patrulha();
            
        }

        if (collision.gameObject.CompareTag("Tiro"))
        {
            StartCoroutine(Morrer());
        }

    }

    IEnumerator Morrer()
    {
        animator.SetTrigger("Morrer");
        audioSource.TocarSom(morrer);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
