using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraPos;
    public Transform playerPos;
    public Vector3 currentVec;
    public float cameraSpeed = 10f;

    private void Start()
    {
        currentVec = cameraPos.position;
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        cameraPos.position = new Vector3(Mathf.Clamp(cameraPos.position.x, playerPos.position.x - 10, playerPos.position.x + 10), Mathf.Clamp(cameraPos.position.y, playerPos.position.y - 2, playerPos.position.y + 2), 0);
        transform.position = Vector3.Lerp(cameraPos.position, playerPos.position, 5f * Time.fixedDeltaTime);

    }
}