using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidS;
    public float spawnTimer = 3f;
    public Transform player;
    public List<AsteroidWeight> weights;

    private float timer = 0;

    public void SetWeights(List<AsteroidWeight> Weights)
    {
        this.weights = Weights;
    }


    // Start is called before the first frame update
    void Start()
    {
        ///timer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) Spawn();
        else timer -= Time.deltaTime;
    }

    public void Spawn()
    {
        GameObject b = Instantiate(asteroidS, transform.position, transform.rotation) as GameObject;

        //b.GetComponent<Rigidbody>().AddForce(transform.forward * b.GetComponent<Enemy>().speed);
        Enemy enemy = b.GetComponent<Enemy>();
        enemy.SetEnemy(RollAsteroidType(), player);
        timer = spawnTimer;
    }

    private AsteroidWeight RollAsteroidType()
    {
        int roll = Random.Range(0, 101);

        int weightSum = 0;

        foreach(AsteroidWeight aw in weights)
        {
            weightSum += aw.weight;

            if(roll < weightSum)
            {
                return aw;
            }
        }

        return new AsteroidWeight(Enemy.AsteroidType.Neutral, 0,1);
    }
}
