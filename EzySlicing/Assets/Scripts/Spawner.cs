using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDelay;
    public float destroyDelay;
    public GameObject spawningPrefab;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        GameObject spawnedObj = Instantiate(spawningPrefab, transform.position, Quaternion.identity);
        Destroy(spawnedObj, destroyDelay);
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnObject());
    }
}
