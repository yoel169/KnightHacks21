using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Spawner spawner;
    public List<GameObject> Asteroids;
    public float spawnerY =50f;
    public float spawnerZ = 50f;
    public float spawnXOffset = 20;
    UIHandler ui;
    public int baseTotalScore = 200;
  
    Player player;
    int difficultyLevel = 0;
    public float timer = 0;
    public int chanceDam = 5, chaneHeal = 15, chanceSpeed = 3, chanceLife = 1;
    public float modRed = 1, modHeal = 50,  modSpeed = 0.1f, modLife = 1;
    public List<AsteroidWeight> weights;

    Vector3 spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIHandler>();
        weights = new List<AsteroidWeight> {
       
           new AsteroidWeight(Enemy.AsteroidType.Heal, chaneHeal, modHeal),
           new AsteroidWeight(Enemy.AsteroidType.Life, chanceLife, modLife),
           new AsteroidWeight(Enemy.AsteroidType.Speed, chanceSpeed, modSpeed),
           new AsteroidWeight(Enemy.AsteroidType.Damage, chanceDam, modRed),
          };

        player = FindObjectOfType<Player>();

        spawnpoint = new Vector3(player.transform.position.x, spawnerY, spawnerZ);

        Spawner s = Instantiate(spawner, spawnpoint, transform.rotation) as Spawner;
        s.SetWeights(weights);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if (player.totalScore == 2 * Mathf.Pow(2, difficultyLevel))
        //{
        //    IncreaseDifficulty();           
        //}

        if (timer >= 10)
        {
            timer = 0;
            SpawnRandom();
        }
    }

    private void IncreaseDifficulty()
    {
        difficultyLevel++;

        ui.UpdateDifficulty(difficultyLevel);

        int counter = 0;
        int modifier = 1;

        for(int x = 0; x < difficultyLevel; x++)
        {

            Vector3 spawnPoint = new Vector3(player.transform.position.x + Random.Range(- spawnXOffset, spawnXOffset), spawnerY, spawnerZ);

            Spawner s = Instantiate(spawner, spawnPoint, transform.rotation) as Spawner;
            s.asteroidS = Asteroids[x].gameObject;
            s.SetWeights(weights);
            s.spawnTimer = Asteroids[x].GetComponent<Enemy>().spawnTime;
            s.spawnTimer /= modifier;

            counter++;

            if(counter >= Asteroids.Count)
            {
                counter = 0;
                modifier++;
                UpdateWeights(modifier);
            }

        }
    }

    public void SpawnRandom()
    {
        int x = Random.Range(0, Asteroids.Count);

        Vector3 spawnPoint = new Vector3(player.transform.position.x + Random.Range(-spawnXOffset, spawnXOffset), spawnerY, spawnerZ);

        Spawner s = Instantiate(spawner, spawnPoint, transform.rotation) as Spawner;
        s.asteroidS = Asteroids[x].gameObject;
        s.SetWeights(weights);
        s.spawnTimer = Asteroids[x].GetComponent<Enemy>().spawnTime;
        
    }

    private void UpdateWeights(int modifier)
    {
        for(int x = 0; x < weights.Count; x++)
        {
            weights[x].weight *= modifier;
        }
    }
}

public class AsteroidWeight
{
    public Enemy.AsteroidType asteroidType;
    public int weight;
    public float modifier;

    public AsteroidWeight(Enemy.AsteroidType type, int weight, float modifier)
    {
        this.weight = weight;
        asteroidType = type;
        this.modifier = modifier;
            
    }
}
