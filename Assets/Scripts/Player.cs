using System.Collections.Generic; // 🔥 ESTA LÍNEA FALTABA
using UnityEngine;

public class Player : IDamageable
{
    public string Name;
    public int Life;
    public int nivel;

    public List<Skill> habilidades = new(); // ahora sí funciona

    public void Move()
    {
        Debug.Log("Player is moving");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Recibi daño!");
    }
}