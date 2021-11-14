using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce = 700f;
    public float bulletTime = 1f;

    private float timer = 0;

    Player player;

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        timer = bulletTime ;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) Shoot();
        else timer -= Time.deltaTime;
    }

    void Shoot()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 5f)).normalized;

        GameObject b = GameObject.Instantiate(bullet, spawnPoint.position, Camera.main.transform.rotation) as GameObject;

        b.GetComponent<Bullet>().InitBullet(player);

        b.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootForce);      

        timer = bulletTime;
    }
}
