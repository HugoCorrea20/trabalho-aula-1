using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 offset;
    public float smoothTime = 0.5f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 midpoint = (player1.position + player2.position) / 2f;
        Vector3 targetPosition = midpoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
