using System.Collections.Generic;

public class TrueFalse : InteriorNode
{
    public override Result Run()
    {
        //condition of first child determines whether second or third child is run
        current_child = 0;

        //pull result of running current child node
        Result res = children[current_child].Run();
        
        //if current child fails, move on to next 
        if (res == Result.FAILURE) {
            current_child+= 2;
            children[current_child].Run();
            return Result.SUCCESS;

        }
        else if(res == Result.SUCCESS) {
            current_child++;
            children[current_child].Run();
            return Result.SUCCESS;
        }

        return Result.FAILURE;
    }

    public TrueFalse(IEnumerable<BehaviorTree> children) : base(children)
    {
    }

    public override BehaviorTree Copy()
    {
        return new TrueFalse(CopyChildren());
    }

}
