using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Cloud : MonoBehaviour
{
    [SerializeField] private double minSpeed;
    [SerializeField] private double maxSpeed;

    [SerializeField] private Sprite cloud0;
    [SerializeField] private Sprite cloud1;
    [SerializeField] private Sprite cloud2;
    [SerializeField] private Sprite cloud3;
    [SerializeField] private Sprite cloud4;
    [SerializeField] private Sprite cloud5;

    private Random rand;

    private double range;
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rand = new Random();

        range = maxSpeed - minSpeed;
        
        Sprite cloudSprite = null;
        int cloudNr = rand.Next(5 - 0 + 1);

        switch(cloudNr)
        {
            case 0:
                cloudSprite = cloud0;
                break;
            case 1:
                cloudSprite = cloud1;
                break;
            case 2:
                cloudSprite = cloud2;
                break;
            case 3:
                cloudSprite = cloud3;
                break;
            case 4:
                cloudSprite = cloud4;
                break;
            case 5:
                cloudSprite = cloud5;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = cloudSprite;

        speed = randomFloat();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if(transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }
    
    private float randomFloat()
    {
        return (float)((rand.NextDouble() * range) + minSpeed);
    }
}
