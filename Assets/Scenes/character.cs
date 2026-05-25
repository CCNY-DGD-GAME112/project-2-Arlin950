using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    protected Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void Move(Vector3 direction)
    {
        direction = direction.normalized;

        Vector3 velocity = direction * moveSpeed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
    }

    protected void LookAtTarget(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public virtual void GetHit(Vector3 forceDirection, float forcePower)
    {
        rb.AddForce(forceDirection * forcePower, ForceMode.Impulse);

        // Update is called once per frame
        void Update()
        {

        }
    }
}