using System.Collections.Generic;
using UnityEngine;
using Sowtank.Utils;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private Inventory<string> inventory = new();
    private Inventory<int> inventory2 = new();

    private Player player;

    public SkillManager skillManager;

    void Start()
    {
        player = new Player();

        player.Name = "Rolando";
        player.Life = 100;
        player.nivel = 5;

        GameUtils.Process<string>(
            "12",
            x => Debug.Log(x));

        GameUtils.Process<Player>(
            player,
            x => x.Move());

        Action test1 = () => Debug.Log("ayuda");

        Action<string> test2 = (value) =>
        {
            Debug.Log(value);
        };

        Action<int, int> test =
            (value1, value2) =>
            Debug.Log(value1 + value2);

        test1?.Invoke();
        test2?.Invoke("ya no necesito ayuda B)");
        test?.Invoke(1, 2);

        Func<string, int> suma = (value) => 12;

        Func<Player, int> getPlayer = GetPlayerLife;

        int Value = GameUtils.Transform<Player, int>(
            player,
            x => x.Life);

        int Value2 = GetPlayerLife(player);

        TestTakeDamage<Player>(player, 15);

        int simpleReturn = ReturnSimple(out string obj);
        print(obj);

        int simpleReturn2 = ReturnSimple(out _);

        Debug.Log(" TODAS LAS HABILIDADES");

        foreach (Skill skill in skillManager.allSkills)
        {
            Debug.Log(skill.nombre);
        }

        Debug.Log(" APRENDER HABILIDADES ");

        foreach (Skill skill in skillManager.allSkills)
        {
            if (skillManager.CanLearnSkill(player, skill))
            {
                player.habilidades.Add(skill);

                Debug.Log("Aprendió: " + skill.nombre);
            }
            else
            {
                Debug.Log("No puede aprender: " + skill.nombre);
            }
        }

        Debug.Log(" HABILIDADES APRENDIDAS ");

        foreach (Skill skill in player.habilidades)
        {
            Debug.Log(skill.nombre);
        }

        Debug.Log(" EJECUTAR HABILIDADES ");

        foreach (Skill skill in player.habilidades)
        {
            SkillManager.ExecuteSkill(
                skill,
                s => s.Ejecutar(player)
            );
        }

        Skill[] skillsArray = skillManager.allSkills.ToArray();

        if (SkillHelper.TryFind(
            skillsArray,
            s => s.id == 1,
            out Skill encontrada))
        {
            Debug.Log("Encontrada: " + encontrada.nombre);
        }

        SkillHelper.TryFind(
            skillsArray,
            s => s.id == 999,
            out _
        );
    }

    public int GetPlayerLife(Player player)
    {
        return player.Life;
    }

    public int TestFunc(string value)
    {
        return 12;
    }

    public void TestTakeDamage<T>(T value, int damage)
        where T : IDamageable
    {
        value.TakeDamage(damage);
    }

    public int ReturnSimple(out string value)
    {
        value = "Ayuda!!";
        return 1;
    }
}