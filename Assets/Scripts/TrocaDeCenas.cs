using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCenas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Play()
    {
        SceneManager.LoadScene("Historia");
    }
     public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Pular()
    {
        SceneManager.LoadScene("Fase1");
    }
}
