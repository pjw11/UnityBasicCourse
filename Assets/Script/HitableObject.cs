using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dropObjects;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField][Range(0, 100)]
    private int itemDropPercent = 0;
    private MeshRenderer meshRenderer;
    private Color originColor;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{damage}�� ���ظ� �Ծ����ϴ�.");

        StartCoroutine(nameof(OnHitAnimation));

        if(itemDropPercent != 0 && dropObjects.Length != 0)
        {
            int percent = Random.Range(0, 100);
            if(percent < itemDropPercent)
            {
                int index = Random.Range(0,dropObjects.Length);
                GameObject clone = Instantiate(dropObjects[index]);

                //Vector3 addPosition = new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
                clone.transform.position = spawnPoint.position;
                clone.transform.localScale = new Vector3(5,5,5); 
            }
        }
    }

    private IEnumerator OnHitAnimation()
    {
        meshRenderer.material.color = Color.black;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
}
