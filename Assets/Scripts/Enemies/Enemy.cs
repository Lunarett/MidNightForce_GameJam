using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private enum State
    {
        waitingForShoot, walking, turning 
    }
    private float health;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float squareSightRange;
    [SerializeField]
    private State currentState;
    private const float SPEED = 1.0f;
    private bool  shootRegistered;
    private float maxWalkingTime;
    private float currentWalkingTime;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed;

    private OnBeatBehaviour behaviour;

    public float BulletSpeed => bulletSpeed;

    private void Start()
    {
        //Player = FindObjectOfType<Player>().Transform;
        behaviour = GetComponent<OnBeatBehaviour>();
        behaviour.enabled = false;
    }

    private void Update()
    {
        if (SearchForPlayer())
        {
            currentState = State.waitingForShoot;
            if(!shootRegistered) RegisterShoot();
        }
        else
        {
            if (shootRegistered) UnregisterShoot();

            currentState = CheckMovementTimeOver() ? State.turning : State.walking;
        }

        switch (currentState)
        {
            case State.walking:
                WalkAround();
                break;
            case State.turning:
                Turn();
                ResetMovementTimer();
                currentState = State.walking;
                break;
            default:
                break;
        }
    }

    private void WalkAround()
    {
        transform.position += transform.up*Time.deltaTime*SPEED;
        currentWalkingTime += Time.deltaTime;
    }

    private void Turn()
    {
        transform.eulerAngles = transform.forward* Random.Range(0, 360);
    }

    private bool CheckMovementTimeOver()
    {
        return currentWalkingTime >= maxWalkingTime;
    }

    private void RegisterShoot()
    {
        behaviour.enabled = true;
        //BeatHandler.Instance.RegisterBeatBehaviour(behaviour);
        shootRegistered = true;
    }

    private void UnregisterShoot()
    {
        behaviour.enabled = false;
        //BeatHandler.Instance.UnregisterBeatBehaviour(behaviour);
        shootRegistered = false;
    }

    private void ResetMovementTimer()
    {
        maxWalkingTime = Random.Range(1.0f, 3.0f);
        currentWalkingTime = 0.0f;
    }

    public void RecieveDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {

    }

    private bool SearchForPlayer()
    {
        return (player.position - transform.position).sqrMagnitude <= squareSightRange;
    }
}
