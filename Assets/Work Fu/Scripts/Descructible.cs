using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descructible : MonoBehaviour
{
    public float descructionTime = 1f;

    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnbleItems;

    private void Start()
    {
        Destroy(gameObject,descructionTime);
    }

    private void OnDestroy()
    {
        if (spawnbleItems.Length > 0 && Random.value < itemSpawnChance)
        {
            int randomIndex = Random.Range(0, spawnbleItems.Length);
            Instantiate(spawnbleItems[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
