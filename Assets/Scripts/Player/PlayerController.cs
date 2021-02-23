using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        //ship movement according to mouse position
        transform.Translate(- Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
