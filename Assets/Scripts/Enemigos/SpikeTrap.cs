using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Transform spikes;
    public float hiddenY = -1f;
    public float raisedY = 0f;

    public float moveSpeed = 5f;

    public float stayUpTime = 1.5f;

    private bool isActivated = false;


    void Start()
    {
        Vector3 pos = spikes.localPosition;
        pos.y = hiddenY;
        spikes.localPosition = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateTrap());
        }

    }

    IEnumerator ActivateTrap()
    {
        isActivated = true;

        // SUBA
        while (spikes.localPosition.y < raisedY)
        {
            Vector3 pos = spikes.localPosition;

            pos.y += moveSpeed * Time.deltaTime;

            spikes.localPosition = pos;

            yield return null;
        }

        // ESPERAR ARRIBA
        yield return new WaitForSeconds(stayUpTime);

        // BAJAR
        while (spikes.localPosition.y > raisedY)
        {
            Vector3 pos = spikes.localPosition;

            pos.y -= moveSpeed * Time.deltaTime;

            spikes.localPosition = pos;

            yield return null;
        }

        Vector3 finalPos = spikes.localPosition;

        finalPos.y = hiddenY;

        spikes.localPosition = finalPos;

        isActivated = false;
    }

}
