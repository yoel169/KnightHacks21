using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 

    public float damage = 5;
    public Player player;
    
    private Vector3 spawn;

    public void InitBullet(Player player)
    {
        this.player = player;
        this.damage = player.damage;
        spawn = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(spawn, transform.position)  >= 100) Destroy(gameObject);
    }

}
