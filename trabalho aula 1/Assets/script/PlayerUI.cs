using UnityEngine;
using UnityEngine.UI;
 using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthText2;
    public personagem player; 
    public personagem player2; // Associe o jogador a este campo no Inspector.

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set in the PlayerUI script.");
            return;
        }

        healthText.text = "Health: " + player.currentHealth.ToString();  
        healthText2.text = "Health: " + player2.currentHealth.ToString();
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // Atualize o texto com a vida atual do jogador.
        healthText.text = "vida jogador 1: " + player.currentHealth.ToString();
        healthText2.text = "vida jogador 2: " + player2.currentHealth.ToString();
    }
}
