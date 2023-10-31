using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public int maxHealth = 100;
    public  int currentHealth;
    public float moveSpeed = 3.0f; // Velocidade de movimento do inimigo
    public float moveDistance = 5.0f; // Distância máxima que o inimigo percorrerá antes de mudar de direção
    private bool movingRight = true; // Inimigo inicialmente se move para a direita
    private Vector3 startPosition;
    private float currentDistance = 0.0f;
    public int damageAmount = 10;

    private void Start()
    {
        currentHealth = maxHealth;
        startPosition = transform.position;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        currentDistance = Vector3.Distance(startPosition, transform.position);

        // Verifique se o inimigo atingiu a distância máxima e, se sim, mude de direção
        if (currentDistance >= moveDistance)
        {
            FlipDirection();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifique se a colisão é com o jogador
        {
            Movimentacao2D playerHealth = collision.gameObject.GetComponent<Movimentacao2D>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
    private void FlipDirection()
    {
        // Inverte a direção do inimigo
        movingRight = !movingRight;

        // Inverte a escala do inimigo para fazer com que ele olhe na direção correta
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Die()
    {
        // Implemente aqui a lógica para o inimigo morrer, como destruí-lo.
        Destroy(gameObject);
    }
}
