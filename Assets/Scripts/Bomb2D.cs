using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2D : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            explode();
        }
    }

    void explode() {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

        foreach(Collider2D obj in objects) {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction*force);
        }

        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffect, 10);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected(){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }


}
