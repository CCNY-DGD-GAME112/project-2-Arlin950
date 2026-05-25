using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 10f;
    public float lifeTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter(Collider other)
    {
        Character target = other.GetComponent<Character>();

        if (target != null)
        {
            target.GetHit(transform.forward, force);
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
