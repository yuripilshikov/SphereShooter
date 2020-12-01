using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const string playerTag = "Player";
    const string bulletTag = "Bullet";
    public float minSpeed = 1.0f;
    public float maxSpeed = 6.0f;
    public int health = 1;
    public int damageToCause = 1;

    float speed;
    GameObject player;
    public GameObject enemyExplosionPrefab;
    AudioSource audioSource;
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed) + (Time.time/25); // speed increases with the game process
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag(playerTag);
    }

    private void FixedUpdate()
    {
        if(player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);
            ScoreManager.instance.IncreaseScore(1);
            audioSource.Play();
            //DestroyEnemy();
            health--;
        }

        if(col.gameObject.CompareTag(playerTag))
        {
            HealthManager.instance.ChangeHealth(-1);
            DestroyEnemy();
        }

        if(health <= 0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        
        GameObject explosionInstance = Instantiate(enemyExplosionPrefab, transform.position, enemyExplosionPrefab.transform.rotation);
        Destroy(explosionInstance, 5.0f);
        //audioSource.Play();
        Transform trailRenderer = transform.GetChild(0);
        if(trailRenderer)
        {
            trailRenderer.parent = null;
            Destroy(trailRenderer.gameObject, trailRenderer.GetComponent<TrailRenderer>().time);
        }

        Destroy(this.gameObject);
    }

}
