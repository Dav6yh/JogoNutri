
using System.Collections;
using TMPro;

using UnityEngine;

public class EscrevaTexto : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI texto;
    [TextArea]
    [SerializeField] private string mensagem1;
    [TextArea]
    [SerializeField] private string mensagem2;
    [TextArea]
    [SerializeField] private string mensagem3;
    [TextArea]
    [SerializeField] private string mensagem4;
    [TextArea]
    [SerializeField] private string mensagem5;

    [SerializeField] private float VelocidadeDigitacao = 0.02f;
    [SerializeField] int contador = 0;

    private bool escrevendo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto.text = "";
        StartCoroutine(DigitarTexto(mensagem1));
    }

    private IEnumerator DigitarTexto(string mensagem)
    {
        foreach (char letra in mensagem)
        {
            texto.text += letra;
            yield return new WaitForSeconds(VelocidadeDigitacao);
        }
    }


    public void ProximoTexto()
    {
        contador++;

        if (contador == 1)
        {
            texto.text = "";
            StartCoroutine(DigitarTexto(mensagem2));

        }
        else if (contador == 2)
        {
            texto.text = "";
            StartCoroutine(DigitarTexto(mensagem3));
        }
        else if (contador == 3)
        {
            texto.text = "";
            StartCoroutine(DigitarTexto(mensagem4));
        }
        else if (contador == 4)
        {
            texto.text = "";
            escrevendo = true;
            StartCoroutine(DigitarTexto(mensagem5));

        }
        else
        {
            contador = 0;
        }
    }

    public bool FinalizaTexto()
    {


        return escrevendo;


    }
}


