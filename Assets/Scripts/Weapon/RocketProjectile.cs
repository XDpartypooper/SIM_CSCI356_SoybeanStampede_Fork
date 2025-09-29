using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 1.5f;

    public int damage { private get; set; }
    public string isShotBy { private get; set; }

    public GameObject EX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            Instantiate(EX, transform.position, transform.rotation);//cosmetic
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.transform.tag == "Enemy" && isShotBy == "Player")
        {
            Instantiate(EX, transform.position, transform.rotation);
            // get the GameObjects that was hit
            Collider[] hitObjects = Physics.OverlapSphere(collision.transform.position, 5f);

            foreach (Collider collider in hitObjects)
            {
                // get Ai_Controls component
                Ai_Controls target = collider.GetComponent<Ai_Controls>();
                // prevent null reference
                if (target != null)
                {
                    target.Damage(damage);
                }
            }
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        // get the rigidbody
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddExplosionForce(0.5f, transform.position, 5f);
        }
    }
}

