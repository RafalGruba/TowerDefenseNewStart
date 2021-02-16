using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public int damage = 50;
    //public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {

        //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 2f);
        if (explosionRadius > 0f)
        {
            Explode();
            //works
        }
        else
        {
            Damage(target);
            //works
        }

        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider2D in colliders)
        {
            Debug.Log("ASD");
            if (collider2D.tag == "Enemy")
            {
                Damage(collider2D.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy_Movement e = enemy.GetComponent<Enemy_Movement>(); // to update with Enemy
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
