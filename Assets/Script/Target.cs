using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float minSpeed = 13;
    public float maxSpeed = 18;
    public float maxTorque = 10;
    public float xRange = 4;
    public float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    [SerializeField] private Rigidbody rigibody;
    public ParticleSystem explosionParticle;

    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        rigibody.AddForce(RandomForce(), ForceMode.Impulse);
        rigibody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation).Play();
        }
        
    }
    // Ham nay nghia la neu co 1 cai food co tag khac "bad" roi xuong ma khong duoc bam thi se thuc hien
    public void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        if (gameObject.CompareTag("Bad") || !gameObject.CompareTag("Bad"))
        {
            gameManager.Winner();
        }
    }

    public Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    public float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    public Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < ySpawnPos)
        {
            Destroy(gameObject);
        }
    }
}