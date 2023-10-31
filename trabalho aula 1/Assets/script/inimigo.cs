using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public int maxHealth = 100;
    public  int currentHealth;
    public float moveSpeed = 3.0f; // Velocidade de movimento do inimigo
    public float moveDistance = 5.0f; // Dist�ncia m�xima que o inimigo percorrer� antes de mudar de dire��o
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

        // Verifique se o inimigo atingiu a dist�ncia m�xima e, se sim, mude de dire��o
        if (currentDistance >= moveDistance)
        {
            FlipDirection();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifique se a colis�o � com o jogador
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
        // Inverte a dire��o do inimigo
        movingRight = !movingRight;

        // Inverte a escala do inimigo para fazer com que ele olhe na dire��o correta
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Die()
    {
        // Implemente aqui a l�gica para o inimigo morrer, como destru�-lo.
        Destroy(gameObject);
    }
}
