using System.Collections.Generic;
using BehaviorTree;

public class BasicBulletBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float fovRange = 6f;

    public static float speed = 2f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOV(transform),
                new GoToTarget(transform),
            }),
            new PatrolTask(transform, waypoints),
        });

        return root;
    }
}
