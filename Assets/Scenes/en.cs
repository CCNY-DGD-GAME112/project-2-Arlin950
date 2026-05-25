using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;

public class En : Character
{
    public Transform player;
    public float detectRange = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float shootInterval = 2f;

    private bool isStunned = false;
    private float shootTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectRange)
        {
            LookAtTarget(player.position);
            Move(transform.forward);
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;
            }
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
    public override void GetHit(Vector3 forceDirection, float forcePower)
    {
        base.GetHit(forceDirection, forcePower);
        StartCoroutine(Stun());
    }
    IEnumerator Stun()
    {
        isStunned = true;

        float originalSpeed = moveSpeed;
        moveSpeed = 0;

        yield return new WaitForSeconds(2f);

        moveSpeed = originalSpeed;
        isStunned = false;
    }
}
