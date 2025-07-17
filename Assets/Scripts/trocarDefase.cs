using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trocarDefase : MonoBehaviour

{
    [SerializeField] private string nomeDaProximaFase = "";
    [SerializeField] private float tempoDeTransicao = 1.0f;
    private Animator animator;

    void Start()
    {
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(nomeDaProximaFase))
            {
                StartCoroutine(TransicaoParaProximaFase());
            }
        }
    }

   IEnumerator TransicaoParaProximaFase()
    {
        animator.SetTrigger("MudarFase");
        yield return new WaitForSeconds(tempoDeTransicao);
        SceneManager.LoadScene(nomeDaProximaFase);
    }
}
