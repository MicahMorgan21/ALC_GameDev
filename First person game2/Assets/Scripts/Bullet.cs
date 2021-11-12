using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifeTime;
    private float shootTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        shootTime = Time.time;
    }

    void OnTriggerEnter(Collider other)
    {
        // Did we hit the player or the Enemy
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        else if(other.CompareTag("Enemy"))
        other.GetComponent<Enemy>().TakeDamage(damage);

        //Disable bullet
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifeTime)
            gameObject.SetActive(false);

        
    }
}
