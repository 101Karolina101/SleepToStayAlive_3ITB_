using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health { get; private set; } = 100;
    public int damage { get; private set; } = 10;
    public float speed { get; private set; } = 1.0f;


}

/*

---TODO---
4 spawn pointy (rohy mapy)
útočí na nejbližší objetk hráče (budova/hráč)
2 typy nepřátel (rychlejší méně hp, pomalejší více hp)
zničení budov -> méně resources do dalšího kola
zničení hráče -> konec hry

*/