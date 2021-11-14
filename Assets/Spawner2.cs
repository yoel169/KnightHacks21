using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public List<GameObject> Asteroids;

    public float spawnerY = 50f;
    public float spawnerZ = 50f;
    public float spawnXOffset = 20;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
