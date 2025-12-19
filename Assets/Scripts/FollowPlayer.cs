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


    bool wasFoxWalking = false;
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        { 
            float distance = Vector3.Distance(transform.parent.position, player.position);

            bool isFoxWalking = animator.GetBool("IsWalking");
            if (isFoxWalking != wasFoxWalking)
            {
                Debug.Log("isFoxWalking = " + isFoxWalking);
                wasFoxWalking = isFoxWalking;
            }

            //if (distance > maxDistance)
            //{
            //    transform.parent.LookAt(player.position);
            //    animator.SetBool("IsWalking", true);
            //    Vector3 direction = (player.position - transform.parent.position).normalized;
            //    rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, direction * speed, Time.deltaTime * 6);
            //}
            //else if (distance < minDistance)
            //{
            //    transform.parent.LookAt(player.position);
            //    Vector3 reversedDirection = (player.position - transform.parent.position).normalized;
            //    rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, reversedDirection * speed, Time.deltaTime * 6);
            //    animator.SetBool("IsWalking", true);
            //}
            //else
            //{
            //    transform.parent.LookAt(player.position);
            //    rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.deltaTime * 6);
            //    animator.SetBool("IsWalking", rb.linearVelocity.magnitude < 0.1f);

            //}

            if (distance > minDistance)
            {
                transform.parent.LookAt(player.position);
                //animator.SetBool("IsWalking", true);
                Vector3 direction = (player.position - transform.parent.position).normalized;
                direction.y = 0;
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, direction * speed, Time.deltaTime * 6);
            }
            else
            {
                transform.parent.LookAt(player.position);
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.deltaTime * 6);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
               

            }
            animator.SetBool("IsWalking", rb.linearVelocity.magnitude > 0.1f);
        }
    }
}
