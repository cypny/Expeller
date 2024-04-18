using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected float health;
    protected float atack;
    public Transform player;
    protected Rigidbody2D rigidbodyEnemy;
    protected Vector2 moveVector;
}
