using UnityEngine;

public class DebugNode : BehaviorTree
{
    string debugMessage;

    public override Result Run()
    {
        Debug.Log(debugMessage);
        return Result.SUCCESS;
    }

    public DebugNode(string message) : base()
    {
        this.debugMessage = message;
    }

    public override BehaviorTree Copy()
    {
        return new DebugNode(debugMessage);
    }
}

