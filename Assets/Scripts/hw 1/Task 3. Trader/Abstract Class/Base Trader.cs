using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseTrader : MonoBehaviour
{
    public virtual void Trade()
    {
        SayHello();
        PresentProduct();
    }

    protected abstract void PresentProduct();
    
    private void SayHello()
    {
        print("Привет, друг!");
    }
}