using UnityEngine;

public class BehaviorBuilder
{
    public static BehaviorTree MakeTree(EnemyController agent)
    {
        BehaviorTree result = null;
        if (agent.monster == "warlock")
        {
            result = new Sequence(new BehaviorTree[] {
                                        new MoveToPlayer(agent.GetAction("attack").range),
                                        new Attack(),
                                        new PermaBuff(),
                                        new Heal(),
                                        new Buff()
                                     });
        }
        else if (agent.monster == "zombie")
        {
            // result = new Sequence(new BehaviorTree[] {
            //                            new MoveToPlayer(agent.GetAction("attack").range),
            //                            new Attack()
            //                          });
            // result = new IndiscriminateSequence(new BehaviorTree[] {
            //     new MoveToPlayer(agent.GetAction("attack").range),
            //     new TrueFalse(new BehaviorTree[] {
            //                             new IsEnemyInAttackRange(agent.GetAction("attack").range),
            //                             new DebugNode("true"),
            //                             new DebugNode("false"),
            //     }),
            //     new Attack()
            // });
            result = new TrueFalse(new BehaviorTree[] {
                new NearbyEnemiesQuery(3,10),
                new Sequence(new BehaviorTree[] {
                    new MoveToPlayer(agent.GetAction("attack").range),
                    new Attack(),
                    new RemoveGroupPoint()
                }),
                new TrueFalse(new BehaviorTree[] {
                    new IsEnemyInAttackRange(agent.GetAction("attack").range),
                    new Attack(),
                    new TrueFalse(new BehaviorTree[] {
                        new DoesGroupPointExist(),
                        new TrueFalse(new BehaviorTree[] {
                            new IsEnemyInPlayerRadius(50),
                            new MoveAwayFromPlayer(50),
                            new Sequence(new BehaviorTree[] {
                                new GoToPoint(GameManager.Instance.groupPoint,10),
                                new NearbyEnemiesQuery(3, 10),
                                new RemoveGroupPoint(),
                                new MoveToPlayer(agent.GetAction("attack").range),
                                new Attack(),
                            })
                        }),
                        new SetGroupPoint(),
                    })
                })
            });
        }
        else
        {
            result = new TrueFalse(new BehaviorTree[] {
                new NearbyEnemiesQuery(3, 10),
                new Sequence(new BehaviorTree[] {
                    new MoveToPlayer(agent.GetAction("attack").range),
                    new Attack()
                }),
                new TrueFalse(new BehaviorTree[] {
                    new IsEnemyInPlayerRadius(50),
                    new MoveAwayFromPlayer(50),
                    new GoToPoint(GameManager.Instance.groupPoint, 2)
                })
            });
        }

        // do not change/remove: each node should be given a reference to the agent
        foreach (var n in result.AllNodes())
        {
            n.SetAgent(agent);
        }
        return result;
    }
}
