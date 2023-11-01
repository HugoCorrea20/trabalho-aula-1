using UnityEngine;
using UnityEngine.InputSystem;


public class personagem : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool hasJumped = false;
    public bool isBoosted = false;
    public float boostedSpeed = 10f; // Velocidade aumentada
    public int maxHealth = 100;
    public  int currentHealth;
    public  int deathCount = 0;
    public float deathHeight = -10.0f; // Defina a altura de morte, ajuste conforme necess�rio
    public GameObject endGamePoint;
    public GameObject fimdejogo;


    private void Start()
{
    currentHealth = maxHealth;
        Time.timeScale = 1;
    
 
}
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        // Verifique a posi��o Y do jogador
        if (transform.position.y < deathHeight)
        {
            Die();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !hasJumped)
        {
            Jump();
        }
    }
    public void OnBoost(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isBoosted = true;
            rb.velocity = Vector2.zero; // Redefine a velocidade para evitar problemas de transi��o
        }
        else if (context.canceled)
        {
            isBoosted = false;
        }
    }
    public void OnHeal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Heal();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack();
        }
    }
    private void Heal()
    {
        int healAmount = 20; // Ajuste a quantidade de cura conforme necess�rio
        currentHealth += healAmount;

        // Certifique-se de que a sa�de n�o excede o valor m�ximo
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Se voc� tiver um segundo jogador, fa�a o mesmo para ele
        // player2.currentHealth += healAmount;
    }

    private void Attack()
    {
        // Implemente a l�gica de ataque aqui
        // Por exemplo, detectar inimigos pr�ximos e causar dano a eles.

        float attackRadius = 1.0f; // Raio de ataque
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy")) // Verifique se o objeto � um inimigo (ajuste a tag conforme necess�rio)
            {
                inimigo enemyHealth = hitCollider.GetComponent<inimigo>();
                if (enemyHealth != null)
                {
                    int damage = 10; // Ajuste a quantidade de dano conforme necess�rio
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == endGamePoint)
        {
            fimdejogo.SetActive(true);
            Debug.Log("Jogo terminou!");
            Time.timeScale = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        deathCount++;

        if (deathCount >= 4)
        {
            // Recarregue a cena
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // Implemente aqui a l�gica para reiniciar o jogador no in�cio do mapa
            // Por exemplo, mova o jogador de volta para a posi��o inicial
            // Certifique-se de ajustar isso de acordo com a sua cena.
            transform.position = Vector3.zero;

            // Redefina a sa�de do jogador, se necess�rio
            currentHealth = maxHealth;
        }
    }
    private void Move()
    {
        float speed = isBoosted ? boostedSpeed : moveSpeed; // Verifica se a velocidade est� aumentada
        Vector2 moveVelocity = moveInput.normalized * speed;
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        hasJumped = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Define a tag do ch�o como "Ground"
        {
            hasJumped = false;
        }
    }


}
