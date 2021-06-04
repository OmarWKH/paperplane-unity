using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject bgPrefab;
    public float changeDuration = 10f;
    private GameObject bgCurrent;
    private float elapsedTime = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (elapsedTime > changeDuration)
        {
            Destroy(bgCurrent);
            Vector3 position = Camera.main.transform.position;
            position.x += 10f;
            position.y -= 4f; 
            position.z = 0;
            bgCurrent = Instantiate(bgPrefab, position, Quaternion.identity);
            bgCurrent.GetComponent<SpriteRenderer>().color =
                new Color(Random.value * 255f, Random.value * 255f, Random.value * 255f);
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
