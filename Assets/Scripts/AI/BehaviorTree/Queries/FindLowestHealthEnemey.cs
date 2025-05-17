using UnityEngine;
using System.Collections.Generic;

public class FindLowestHealthEnemy : BehaviorTree
{
    float distance;

    public override Result Run()
    {
        var nearby = GameManager.Instance.GetEnemiesInRange(agent.transform.position, distance);
        if (nearby.Count == 0)
        {
            return Result.FAILURE;
        }

        int indexOfLowestHealthEnemy = 0;
        float LowestHealth = 10000f;
        for(int i = 0; i < nearby.Count; i++) {
            float currentEnemyHealth =nearby[i].GetComponent<EnemyController>().hp.hp;
            if(currentEnemyHealth < LowestHealth) {
                indexOfLowestHealthEnemy = i;
                LowestHealth = currentEnemyHealth;
            }
        }
        GameManager.Instance.lowestHealthEnemy = nearby[indexOfLowestHealthEnemy].transform.position;
        return Result.SUCCESS;
    }

    public FindLowestHealthEnemy(float distance) : base()
    {
        this.distance = distance;
    }

    public override BehaviorTree Copy()
    {
        return new FindLowestHealthEnemy(distance);
    }
}
