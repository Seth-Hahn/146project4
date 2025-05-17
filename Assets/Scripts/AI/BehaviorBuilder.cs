using UnityEngine;

public class BehaviorBuilder
{
    public static BehaviorTree MakeTree(EnemyController agent)
    {
        BehaviorTree result = null;
        if (agent.monster == "warlock")
        {
            result = new Selector(new BehaviorTree[] {
                new Sequence(new BehaviorTree[] {
                    new DoesGroupPointExist(),
                    new GoToPoint(GameManager.Instance.groupPoint, 3),
                    new PermaBuff(),
                    new Buff(),
                    new Heal(),
                }),
                new Sequence(new BehaviorTree[]{
                    new MoveToPlayer(15),
                    new Heal(),
                    new Buff(),
                    new PermaBuff(),
                })
            });
        }

        else if (agent.monster == "zombie")
        {
            result = new TrueFalse(new BehaviorTree[] {
                new NearbyEnemiesQuery(8,20),
                new Sequence(new BehaviorTree[] {
                    new RemoveGroupPoint(),
                    new MoveToPlayer(agent.GetAction("attack").range),
                    new Attack(),
                    //new RemoveGroupPoint()
                }),
                new TrueFalse(new BehaviorTree[] {
                    new IsEnemyInAttackRange(20),
                    new Sequence(new BehaviorTree[] {
                        new MoveToPlayer(agent.GetAction("attack").range),
                        new Attack()
                    }),
                    new TrueFalse(new BehaviorTree[] {
                        new DoesGroupPointExist(),
                        new TrueFalse(new BehaviorTree[] {
                            new IsEnemyInPlayerRadius(25),
                            new MoveAwayFromPlayer(50),
                            new Sequence(new BehaviorTree[] {
                                new GoToPoint(GameManager.Instance.groupPoint,10),
                                new NearbyEnemiesQuery(10, 10),
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
        {   //TODO: FIX SKELETON BUGGY MOVEMENT WHERE IT GETS STUCK OUTSIDE PLAYER RANGE
            result = new TrueFalse(new BehaviorTree[] {
                new NearbyEnemiesQuery(8, 20),
                new Sequence(new BehaviorTree[] {
                    new MoveToPlayer(agent.GetAction("attack").range),
                    new Attack(),
                    new MoveAwayFromPlayer(20),
                }),
                new TrueFalse(new BehaviorTree[] {
                    new IsEnemyInAttackRange(10),
                    new Sequence(new BehaviorTree[] {
                        new MoveToPlayer(agent.GetAction("attack").range),
                        new Attack(),
                        new MoveAwayFromPlayer(20)
                    }),
                    new Sequence(new BehaviorTree[] {
                        new IsEnemyInPlayerRadius(20),
                        new MoveAwayFromPlayer(50),
                        new GoToPoint(GameManager.Instance.groupPoint, 2)
                    })
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
