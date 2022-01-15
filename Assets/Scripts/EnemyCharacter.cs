using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCharacter : BaseCharacter
{
    protected static int _enemyCount = 0;

    public override void Action()
    {
        //Atacar
    }

    public override void Move()
    {
        //moverse claramente
    }

    public override void Die()
    {
        _enemyCount--;
        //Destroy(gameObject);
    }


}

public class TankEnemy : EnemyCharacter
{
    public TankEnemy()
    {
        /*
        stats.life = 100;
        stats.dmg = 75;
        stats.speed = 2f;
        stats.range = 25f;

        Los comento porque después me fijo con más atención que poner en cada uno
        */

        _enemyCount++;
    }
}


public class FastEnemy : EnemyCharacter
{
    public FastEnemy()
    {
        /*
        stats.life = 100;
        stats.dmg = 75;
        stats.speed = 2f;
        stats.range = 25f;

        Los comento porque después me fijo con más atención que poner en cada uno
        */

        _enemyCount++;
    }
}
