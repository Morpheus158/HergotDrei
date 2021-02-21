using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3000f;

    public Rigidbody rb;
    Vector3 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;
        movement.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //print(rb.position);
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(mousePosition - transform.position, Vector3.forward);

        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
    }
}
