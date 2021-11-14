using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum AsteroidType { Neutral, Heal, Damage, Speed, Shields, Life }

    public float health = 20;
    public int damage = 10;
    public int scoreToGive = 5;
    public float speed = 10;
    public float spawnTime = 1;
    public Transform playerLocationTarget;
    

    public AsteroidType asteroidType = AsteroidType.Neutral;
    public float asteroidModifier = 0;

    public Vector3 randMod;

    public void SetEnemy(AsteroidWeight astroWeight, Transform location)
    {
        playerLocationTarget = location;
        asteroidType = astroWeight.asteroidType;
        this.asteroidModifier = astroWeight.modifier;

        HandleTypeCreation();
    }

    private void HandleTypeCreation()
    {
        Material m = GetComponent<Renderer>().material;

        switch (asteroidType)
        {
            case AsteroidType.Neutral:
                break;

            case AsteroidType.Damage:
                m.color = Color.red;
                break;

            case AsteroidType.Heal:
                m.color = Color.green;
                break;

            case AsteroidType.Life:
                m.color = Color.magenta;
                break;

            case AsteroidType.Speed :
                m.color = Color.HSVToRGB(34, 100, 100);
                break;

            default:
                m.color = Color.white;
                break;
        }           
    }

    // Start is called before the first frame update
    void Start()
    {
        playerLocationTarget = FindObjectOfType<Player>().gameObject.transform;

        randMod = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLocationTarget != null)
        {
            Vector3 moveDir = ((playerLocationTarget.position + randMod) - transform.position).normalized;

            transform.position += moveDir * speed * Time.deltaTime;
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            health -= collision.transform.GetComponent<Bullet>().damage;

            if (health <= 0)
            {
                HandleTypeReward(collision.transform.GetComponent<Bullet>().player);

                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
       
    }

    private void HandleTypeReward(Player player)
    {
        Material m = GetComponent<Material>();

        player.GiveScore(scoreToGive);

        switch (asteroidType)
        {
            case AsteroidType.Neutral:
                break;

            case AsteroidType.Damage:
                player.IncreaseDamage(asteroidModifier);
                break;

            case AsteroidType.Heal:
                player.GiveHealth(asteroidModifier);
                break;

            case AsteroidType.Speed:
                player.IncreaseSpeed(asteroidModifier);
                break;

            case AsteroidType.Life:
                
                break;

            default:             
                break;
        }
    }


}
