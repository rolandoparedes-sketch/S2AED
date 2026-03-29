using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/Skill")]
public class Skill : ScriptableObject
{
public int id;
public string nombre;
public int costo;
public int nivelRequerido;

public void Ejecutar(Player player)
{
    Debug.Log($"Ejecutando habilidad: {nombre} en {player.Name}");
}
}
