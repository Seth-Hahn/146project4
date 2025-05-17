using UnityEngine;
using System.Collections.Generic;

public class IsEnemyAboveHalfHealth : BehaviorTree
{
    EnemyController enemy;

    public override Result Run()
    {
        if(enemy.hp.hp < (enemy.hp.max_hp / 2)) {
            return Result.FAILURE;
        }
        
        return Result.SUCCESS;
    }

    public IsEnemyAboveHalfHealth(EnemyController enemy) : base()
    {
        this.enemy = enemy;
    }

    public override BehaviorTree Copy()
    {
        return new IsEnemyAboveHalfHealth(enemy);
    }
}
