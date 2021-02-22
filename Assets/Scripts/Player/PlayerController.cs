using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;

    private void Update()
    {
        //ship movement according to mouse position
        transform.Translate(- Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Translate(- Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        //facing mouse cursor
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDirection = mousePosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(mouseDirection, Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
    }
}
