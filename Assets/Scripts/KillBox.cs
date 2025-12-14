using UnityEngine;

public class KillBox : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation;
    [SerializeField] private GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hits");
        if (other.CompareTag("Player"))
        {
            Player.transform.position = new Vector3(-8, 0, 30);  
            Debug.Log(other.gameObject.name);
        }
    }
}

