using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class PlayerData : ScriptableObject
{

    [Header("General Settings")]
    public float maxHealth;
    public float iFrameTime = 0.5f;
    public float playerHeight = 1;
    [Header("Run")]
    public float moveSpeed;
    public float maxForce;
    public float groundedDrag = 5f;
    public float airDrag = 0f;


    [Header("Jump")]
    public float jumpTimer = 0.1f;
    public float jumpForce = 4f;

    [Header("Look")]
    public float maxAngle = 60;
    public float sensitivity = 0.01f;
    [Header("Physics Gun")]
    public float minimumRange = 0;
    public float maximumRange = 12;
    public float scrollSpeed = 1;
    public float grappleMassThreshold = 100;
    public float springAmount = 282;
    public float damper = 70;
    public Vector2 minMaxDist = new Vector2(0, 3);

}
