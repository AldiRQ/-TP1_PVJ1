using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [Header("Movement")]
    public float Speed = 15f;

    [Header("Lifetime")]
    public float Lifetime = 5f;

    private Vector3 moveDirection;

    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.position += moveDirection * Speed * Time.deltaTime;
    }
}
