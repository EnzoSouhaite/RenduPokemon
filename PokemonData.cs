using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{

    public string PokemonName = "Noctali";
    public int ViePokemonMax = 100;
    private int ViePokemonNow = 100;
    public int Attack = 10;
    public int Defense = 40;
    private int Stat = 150;
    public float Weight = 10.7f;

    public enum Types

    {
        Normal,
        Fire,
        Water,
        Grass,
        Electric,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Dragon,
        Dark,
        Steel,
        Fairy,
    }

    Types currentTypes = Types.Dark;

    public Types[] faiblesseTypes = { Types.Bug, Types.Fighting, Types.Fairy };
    public Types[] resistanceTypes = { Types.Psychic, Types.Ghost };

    private void Start()
    {
        
        DisplayName();
        DisplayMax();
        DisplayAttack();
        DisplayDefense();
        DisplayWeight();
        Displayfaiblesse();
        Displayresistance();

        InitCurrentStat();
        InitCurrentLife();

        GetAttackdamage();
        TakeDamage(10, Types.Fire);
        TakeDamage(10, Types.Fire);
        TakeDamage(10, Types.Fire);
    }

    void Update()
    {
        CheckifPokemonAlive();
    }

    bool weaknessTypes(Types Oppenent)
    {
        foreach(Types faiblesse in faiblesseTypes)
        {
            if (faiblesse == Oppenent)
            {
                return true;
            }
        }
        return false;
    }

    bool resistTypes(Types Oppenent)
    {
        foreach(Types resistance in resistanceTypes)
        {
            if (resistance == Oppenent)
            {
                return true;
            }
        }
        return false;
    }

    public void TakeDamage(int damage, Types EnnemyTypes)
    {
        if (weaknessTypes(EnnemyTypes))
        {
            ViePokemonNow -= damage * 2;
            Debug.Log("La Vie actuel de " + PokemonName + " est de " + ViePokemonNow);
        }

        else if (resistTypes(EnnemyTypes))
        {
            ViePokemonNow -= damage / 2;
            Debug.Log("La Vie actuel de " + PokemonName + " est de " + ViePokemonNow);
        }

        else
        {
            ViePokemonNow -= damage;
            Debug.Log("La Vie actuel de " + PokemonName + " est de " + ViePokemonNow);
        }
    }

    void CheckifPokemonAlive()
    {
        if (ViePokemonNow <= 0)
        {
            Debug.Log(PokemonName + " est K.O ! ");
        }
    }
    int GetAttackdamage()
    {
        Debug.Log(PokemonName + " attaque et fait " + Attack + " de dégâts !");
        return Attack;
    }

    void DisplayName()
    {
        Debug.Log("Le Nom du Pokémon est " + PokemonName);
    }

    void DisplayMax()
    {
        Debug.Log("La Vie Max de " + PokemonName + " est de " + ViePokemonMax);
    }

    void DisplayAttack()
    {
        Debug.Log(PokemonName + " possèdent une attaque de " + Attack + " de puissance !");
    }

    void DisplayDefense()
    {
        Debug.Log(PokemonName + " possèdent une défense de " + Defense + " de puissance !");
    }

    void DisplayWeight()
    {
        Debug.Log(PokemonName + " pèse " + Weight + " kg ");
    }

    void Displayfaiblesse()
    {
        Debug.Log(PokemonName + " est faible face au type " + Types.Bug + ", " + Types.Fighting + ", " + Types.Fairy);
    }

    void Displayresistance()
    {
        Debug.Log(PokemonName + " est résistant face au type " + Types.Psychic + ", " + Types.Ghost);
    }

    private void InitCurrentStat()
    {
        Stat = Attack + Defense + ViePokemonMax;
        Debug.Log(PokemonName + " à un total Stats de " + Stat);
    }

    private void InitCurrentLife()
    {
        ViePokemonNow = ViePokemonMax;
        Debug.Log(" La Vie actuel de " + PokemonName + " est de " + ViePokemonNow);
    }
}