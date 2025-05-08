using System.Collections.Generic;

public class Selector : InteriorNode
{
    public override Result Run()
    {

        //went through each child node and each one failed
        if(current_child >= children.Count) {
            current_child = 0;
            return Result.FAILURE;
        }

        //pull result of running current child node
        Result res = children[current_child].Run();
        
        //if current child fails, move on to next 
        if (res == Result.FAILURE) {
            current_child++;
        }
        else if(res == Result.SUCCESS) {
            current_child = 0;
            return Result.SUCCESS;
        }

        return Result.IN_PROGRESS;
    }

    public Selector(IEnumerable<BehaviorTree> children) : base(children)
    {
    }

    public override BehaviorTree Copy()
    {
        return new Selector(CopyChildren());
    }

}
