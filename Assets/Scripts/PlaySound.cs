using Unity.VisualScripting;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private GameObject TargetObject;
    private AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource = TargetObject.GetComponent<AudioSource>();
        AudioSource.Play();
        gameObject.SetActive(false);
    }
}
