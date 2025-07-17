using System.Collections;
using TMPro;
using UnityEngine;

public class EscreveTexto : MonoBehaviour
{





    [SerializeField] private TextMeshProUGUI texto;
    [TextArea]
    [SerializeField] private string mensagemCompleta;
    [SerializeField] private float velocidadeDigitacao = 0.05f;

    private bool escrevendo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto.text = "";
        StartCoroutine(DigitarTexto());

    }
    private IEnumerator DigitarTexto()
    {
        escrevendo = true;
        foreach (char letra in mensagemCompleta)
        {
            texto.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);

        }
        escrevendo = false;
    }



}
