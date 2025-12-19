using System.Runtime.InteropServices;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float speed;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;

    
    private Rigidbody rb;

    private void Awake()
    {
         rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        { 
            float distance = Vector3.Distance(transform.parent.position, player.position);

            if (distance > maxDistance)
            {
                transform.parent.LookAt(player.position);
                Vector3 direction = (player.position - transform.parent.position).normalized;
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, direction * speed, Time.deltaTime * 6);
                animator.SetBool("IsWalking", true);
            }

            if (distance < minDistance)
            {
                transform.parent.LookAt(player.position);
                Vector3 reversedDirection = (player.position - transform.parent.position).normalized;
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, reversedDirection * speed, Time.deltaTime * 6);
                animator.SetBool("IsWalking", true);
            }

            else
            {
                transform.parent.LookAt(player.position);
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.deltaTime * 6);
                animator.SetBool("IsWalking", false);

            }
        }
    }
}
