using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected float speed;
    protected float health;

    protected float atack;
    protected bool isTargetMouse = false;
    public Transform target;
    public static float moseSpeed = 7.5f;
    private float vectorlength;
    protected Rigidbody2D rigidbodyUnit;
    protected Vector2 moveTargetVector;
    protected Vector2 moveToMouseVector;
    public void OnMouseDown()
    {
        isTargetMouse = true;
    }
    protected void MovetoMouse()
    {

        var mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveToMouseVector = GetOrtVectorInPosition(mouse, rigidbodyUnit.position);
        CoinText.Coin += (int)Math.Sqrt(moveToMouseVector.x * moveToMouseVector.x + moveToMouseVector.y * moveToMouseVector.y);
        rigidbodyUnit.velocity += moveToMouseVector * moseSpeed;
    }
    protected Vector2 GetOrtVectorInPosition(Vector3 first, Vector3 second)
    {
        /// first: точка куда идем , second: от куда 
        var rez = new Vector2();
        rez.x = first.x - second.x;
        rez.y = first.y - second.y;
        vectorlength = (float)Math.Sqrt(rez.x * rez.x + rez.y * rez.y);
        rez.x = rez.x / vectorlength;
        rez.y = rez.y / vectorlength;
        return rez;
    }
    public float GetAtk()
    {
        return atack;
    }
    protected void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            CoinText.Coin += 100;
            Destroy(gameObject);
        }
    }

}
