using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;

    public float Speed { get => speed; set => speed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
}
