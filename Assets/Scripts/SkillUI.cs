using TMPro;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI skillsText;

    public void Mostrar(Player player)
    {
        levelText.text = "Nivel: " + player.nivel;

        skillsText.text = "Habilidades:\n";

        foreach (Skill skill in player.habilidades)
        {
            skillsText.text += skill.nombre + "\n";
        }
    }
}
