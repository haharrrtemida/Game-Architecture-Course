using UnityEngine;

namespace hw1.task3
{
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
}