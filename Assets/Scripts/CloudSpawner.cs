using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloud;

    private Random rand;

    private float minY;
    private float maxY;
    private double range;
    
    // Start is called before the first frame update
    void Start()
    {
        rand = new Random();
        
        minY = 1.6f;
        maxY = 4f;
        range = maxY - minY;
        
        InvokeRepeating(nameof(spawnCloud), 1f, 1f);
    }

    private void spawnCloud()
    {
        Vector3 pos = new Vector3(11, randomFloat(), 0);
        GameObject gameObject = Instantiate(cloud, pos, Quaternion.identity);
    }

    private float randomFloat()
    {
        return (float)((rand.NextDouble() * range) + minY);
    }
}
