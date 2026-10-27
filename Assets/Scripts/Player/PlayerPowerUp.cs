using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    [Header("Visual")]
    public float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerController player = other.GetComponent<playerController>();

        if (player != null)
        {
            player.UnlockShootPower();
        }

        Destroy(gameObject);
    }
}
