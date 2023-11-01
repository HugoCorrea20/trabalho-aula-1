using UnityEngine;
using TMPro;

public class Placar : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI textMeshPro2; // Refer�ncia ao componente TMP Text
    public personagem jogador; // Refer�ncia ao script do jogador
    public personagem jogador2; // Refer�ncia ao script do jogador

    private void Start()
    {
        UpdatePlacar(); // Atualize o placar quando o jogo come�ar
    }

    private void UpdatePlacar()
    {
        textMeshPro.text = "Mortes jogador 1: " + jogador.deathCount.ToString();
        textMeshPro2.text = "Mortes jogador 2 : " + jogador2.deathCount.ToString();
    }

    private void Update()
    {
        UpdatePlacar(); // Atualize o placar continuamente
    }
}
