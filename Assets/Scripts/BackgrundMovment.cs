using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrundMovment : MonoBehaviour
{
    [SerializeField] private float X = 2f;
    private Rigidbody2D Posi;
    private void Start()
    {
        Posi = GetComponent<Rigidbody2D>();
        Posi.velocity = new Vector2(X, 0);
    }

}
