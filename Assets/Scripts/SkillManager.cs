using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillManager", menuName = "Scriptable Objects/SkillManager")]
public class SkillManager : ScriptableObject
{

    public List<Skill> allSkills;

    // 🔹 Ejecutar acción (Action<T>)
    public static void ExecuteSkill<T>(T element, Action<T> action)
    {
        action?.Invoke(element);
    }

    // 🔹 Validar condición (Func<T, bool>)
    public static bool Validate<T>(T element, Func<T, bool> condition)
    {
        return condition?.Invoke(element) ?? false;
    }

    // 🔹 Verificar si puede aprender skill
    public bool CanLearnSkill(Player player, Skill skill)
    {
        return Validate(skill, s => player.nivel >= s.nivelRequerido);
    }
}
