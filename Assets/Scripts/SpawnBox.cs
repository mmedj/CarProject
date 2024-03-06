using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject box;
    public GameObject coin;
    public Transform car;

    private void Start()
    {
        StartCoroutine(InstantiateBoxCoroutine());
        StartCoroutine(InstantiateCoins());
    }

    private void Update()
    {
    }
    IEnumerator InstantiateBoxCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            float randomX = Random.Range(-15f, 15f);
            float timer = Random.Range(0.5f, 2f);
            Vector3 boxPosition = new Vector3(randomX, 1.5f, car.position.z + 100f);
            Instantiate(box, boxPosition, Quaternion.identity);
            yield return new WaitForSeconds(timer);
        }
    }
    IEnumerator InstantiateCoins()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            float randomX = Random.Range(-15f, 15f);
            float timer = Random.Range(0.5f, 1f);
            Vector3 coinPosition = new Vector3(randomX, 1.5f, car.position.z + 100f);
            GameObject newCoin = Instantiate(coin, coinPosition, Quaternion.identity);
            newCoin.transform.rotation = Quaternion.Euler(90f, 0f, 180f);
            yield return new WaitForSeconds(timer);
        }
    }
}
