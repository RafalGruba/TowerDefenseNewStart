using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    // to change Enemy_Movement to Enemy

    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public int health = 100;
    public int value = 15;
    public GameObject deathEffect;
    private void Start()
    {
        //Debug.Log(Random.Range(1, 3));
        target = Waypoints.pointsYellow[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);

        
    }


    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.9f)
        {
            GetNextWaypoint();
        }
    }


    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.pointsYellow.Length - 2)
        {
            EndPath();
            //Debug.Log("niszcz");
            return;
        }
        //Debug.Log("idź dalej" + wavepointIndex);
        wavepointIndex++;
        target = Waypoints.pointsYellow[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
