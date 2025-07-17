using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    private int dir = 1;
    private float speed;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1 * speed * Time.deltaTime,0,0);

    }
    void patrulha()
    {
        if(dir == 1)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dir == 1)
        {
            dir = -1;
            other.gameObject.CompareTag("Direita");
        }
       else
        { 
            dir = 1;
            other.gameObject.CompareTag("Esquerda");
        }
    }




}
