
using UnityEngine;

public class ArabaYokEt : MonoBehaviour
{
    public GameObject ArabaSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Araba"))
        {
            ArabaSpawn.gameObject.GetComponent<ArabaSpawn>().Rast= Random.Range(2F, 10f);
            ArabaSpawn.gameObject.GetComponent<ArabaSpawn>().Basla = true;
            Destroy(other.gameObject);
        }
    }
}
