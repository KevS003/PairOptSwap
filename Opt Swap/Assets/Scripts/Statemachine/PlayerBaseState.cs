using UnityEngine;

public abstract class PlayerBaseState 
{
    public abstract void EnterState(PlayerStateManager player);
    public abstract void tick(PlayerStateManager player);
    public abstract void OnExit(PlayerStateManager player);
}
