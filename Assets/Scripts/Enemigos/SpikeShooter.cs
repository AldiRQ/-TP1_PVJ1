using System.Collections;
using UnityEngine;

public class SpikeShooter : MonoBehaviour
{
    public  GameObject spikePrefab;

    public Transform shootPoint;

    public float shootDelay;

    private bool hasShot = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasShot) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShootSpike());
        }
    }

    IEnumerator ShootSpike()
    {
        hasShot = true;

        yield return new WaitForSeconds(shootDelay);

        GameObject spike = Instantiate(spikePrefab, shootPoint.position, shootPoint.rotation);

        SpikeProjectile projectile = spike.GetComponent<SpikeProjectile>();

        projectile.SetDirection(shootPoint.forward);

        yield return new WaitForSeconds(2f);

        hasShot = false;
    }
}
