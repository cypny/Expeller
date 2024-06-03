using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWall : MonoBehaviour
{
    private Rigidbody2D rigidbodyUnit;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbodyUnit.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
