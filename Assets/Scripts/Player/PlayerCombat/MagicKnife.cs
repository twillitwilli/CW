using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKnife : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * 2000);
    }
}
