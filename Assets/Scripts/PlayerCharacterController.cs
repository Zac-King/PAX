using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    private float m_BaseMovementSpeed = 0;
    [SerializeField]
    private float m_RotateSpeed = 0;
    [SerializeField]
    private float m_JumpPower = 0;
    private float m_MovementSpeed;

    float GroundDistance = 0.1f;

    float h; //horizontal movement
    float v; //vertical movement

    bool sprint;

    Rigidbody rb;

    Vector3 HorizontalVelocity;
    Vector3 VerticalVelocity;

    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Forward;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        AddListeners();
    }

    // Use this for initialization
    void Start()
    {
        Messenger.Broadcast<string>("Player", gameObject.name);
	}

    void AddListeners()
    {
        Messenger.AddListener<float,float>(gameObject.name + ":", Movement);
        Messenger.AddListener(gameObject.name + ":Jump", Jump);
        Messenger.AddListener(gameObject.name + ":Attack", Attack);
        Messenger.AddListener(gameObject.name + ":Sprint", Sprint);
        Messenger.AddListener(gameObject.name + ":Special", SpecialAttack);
    }


    #region Event

    void Movement(float a, float b)
    {
        h = b;
        v = a;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * m_JumpPower, ForceMode.VelocityChange);
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void SpecialAttack()
    {
        Debug.Log("Special Attack");
    }

    void Sprint()
    {
        sprint = true;
    }

    #endregion

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (sprint == true)
        {
            m_MovementSpeed = 5.0f;
        }
        else if(sprint == false)
        {
            m_MovementSpeed = m_BaseMovementSpeed;
        }
        
        if(HorizontalVelocity + VerticalVelocity != Vector3.zero)
        {
            Forward = HorizontalVelocity + VerticalVelocity;
            transform.forward = Forward;
        }

        HorizontalVelocity.x = (h / m_MovementSpeed);
        VerticalVelocity.z = (v / m_MovementSpeed);

        Position = (HorizontalVelocity + VerticalVelocity);

        transform.position += Position;

        sprint = false;
    }

    void CheckGroundDistance()
    {
        RaycastHit HitInfo;
    }
}
