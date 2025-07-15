using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] private int dano;
    [SerializeField] private GameObject destroyTiroPreFab;

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(destroyMachadoPreFab, transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}