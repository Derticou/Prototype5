using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    public ParticleSystem explosionParticle;

    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -2;

    

    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Blade" && gameManager.isGameActive)
        {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                gameManager.UpdateScore(pointValue);
        }
        Destroy(gameObject);  
        if (col.tag=="Sensor" && !gameObject.CompareTag("Bad")) { gameManager.gameOver(); }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos() { 
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
