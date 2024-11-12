using UnityEngine;

public abstract class State
{
    public abstract void Enter();

    public abstract void Tick();

    public abstract void Exit();

    protected float GetNormalizedTime(Animator animator)
    {
        var currenInfo = animator.GetCurrentAnimatorStateInfo(0);
        var nextInfo = animator.GetNextAnimatorStateInfo(0);
        if (animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }

        if (!animator.IsInTransition(0) && currenInfo.IsTag("Attack"))
        {
            return currenInfo.normalizedTime;
        }

        return 0;
    }
}
