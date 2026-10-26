using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 5f;

    private Vector3 moveDirection;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerController>().Die();
            Destroy(gameObject);
        }    
    }
}
