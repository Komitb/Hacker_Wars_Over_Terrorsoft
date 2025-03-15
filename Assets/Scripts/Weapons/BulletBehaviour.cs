using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(EnableCollisionDelay());

        SetDestroyTime();

        SetStraightVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checkea si la colisión esta dentro de la "whatDestroysBullet" layerMask

        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            // Spawnear particulas

            // Reproducir sonido

            // Temblor de la pantalla

            // Hacer daño

            // Destruir la bala
            Destroy(gameObject);
        }
    }

    // Que la bala vaya recta
    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    // Despues de x segundos que la bala desaparezca si no colisiona con nada
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
    private IEnumerator EnableCollisionDelay()
    {
        Collider2D bulletCollider = GetComponent<Collider2D>();
        bulletCollider.enabled = false;
        yield return new WaitForSeconds(0.07f);
        bulletCollider.enabled = true;
    }
}
