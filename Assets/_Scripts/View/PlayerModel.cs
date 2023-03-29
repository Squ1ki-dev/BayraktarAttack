using Tools.Reactive;
using UnityEngine.Events;

public class PlayerModel
{
    // public Reactive<int> Hp { get; private set; } = new();
    public Reactive<int> Scores { get; private set; } = new();
    // public UnityEvent onDead = new();
    // public void DealDamage(int countDamage)
    // {
    //     Hp.value -= countDamage;
    //     if (Hp.value <= 0) Kill();
    // }
    // public void Kill()
    // {
    //     onDead.Invoke();
    // }
}