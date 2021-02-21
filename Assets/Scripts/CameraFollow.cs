using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;
    public float scrollSpeed = 1000f;

    private Vector3 velocity = Vector3.zero;

    private Camera cam;

    private void Start()
    {
        this.cam = (Camera)this.gameObject.GetComponent("Camera");
        this.cam.orthographic = true;
        this.cam.orthographicSize = 40f;

        Vector3 cameraDistance = target.position - cam.transform.position;
    }

    void Update()
    {
        this.cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}