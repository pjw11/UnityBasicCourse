using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private float respawnTime = 5;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    public float RespawnTime => respawnTime;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    public void Deactivate()
    {
        meshRenderer.enabled = false;
        meshCollider.enabled = false;

        StartCoroutine(nameof(RespawnProcess));
    }
    private IEnumerator RespawnProcess()
    {
        yield return new WaitForSeconds(respawnTime);

        meshRenderer.enabled = true;
        meshCollider.enabled = true;
    }
}
