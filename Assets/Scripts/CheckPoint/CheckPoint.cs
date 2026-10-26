using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        playerController player = other.GetComponent<playerController>();

        if (player != null)
        {
            player.SetSpawnPoint(transform);
        }
    }
}
