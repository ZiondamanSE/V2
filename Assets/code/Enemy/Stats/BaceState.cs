using UnityEditor;

public abstract class BaceState
{

    public Enemy enemy;
    public StateMechine stateMechine;


    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}