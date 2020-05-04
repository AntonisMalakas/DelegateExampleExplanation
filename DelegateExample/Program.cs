using System;

namespace DelegateExample
{
    class Program
    {
        DelegateClass newDelegateClass = new DelegateClass();
        ActionClass newClass = new ActionClass();
        ActionWithTypeClass newActionWithTypeClass = new ActionWithTypeClass();
        FuncClass newFuncClass = new FuncClass();
        FuncWithResultClass newFuncWithResultClass = new FuncWithResultClass();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ActionMethod();
        }
        public void ActionMethod()
        {
            newDelegateClass.Start();
            newDelegateClass.delegateFunction();
            Console.WriteLine(newDelegateClass.boolDelegateFunction(5));
            Console.WriteLine(newDelegateClass.boolDelegateFunction(25));
            Console.WriteLine(newDelegateClass.boolDelegateFunction(533));
            Console.WriteLine(newDelegateClass.boolDelegateFunction(45));
            newDelegateClass.End();
            newDelegateClass.delegateFunction();


            newClass.Start();
            newClass.actionFunction();
            newClass.End();
            newClass.actionFunction();

            newActionWithTypeClass.Start();
            newActionWithTypeClass.actionFunction(5, 2);

            newFuncClass.Start();
            Console.WriteLine(newFuncClass.funcFunction());

            newFuncWithResultClass.Start();
            Console.WriteLine(newFuncWithResultClass.funcFunction(5));
            Console.WriteLine(newFuncWithResultClass.funcFunction(111));
            Console.WriteLine(newFuncWithResultClass.funcFunction(23));
            Console.WriteLine(newFuncWithResultClass.funcFunction(2));


            Console.ReadLine();
        }

    }

    class DelegateClass
    {
        public delegate void DelegateFunction();
        public delegate bool BoolDelegateFunction(int i);

        public DelegateFunction delegateFunction;
        public BoolDelegateFunction boolDelegateFunction;



        public void Start()
        {
            delegateFunction = MyDelegateFunction;
            boolDelegateFunction = MyBoolDelegateFunction;
        }
        public void End()
        {
            delegateFunction = MyEndDelegateFunction;
        }

        private void MyDelegateFunction()
        {
            Console.WriteLine("MyDelegateFunction");
        }
        private void MyEndDelegateFunction()
        {
            Console.WriteLine("MyEndDelegateFunction");
        }

        private bool MyBoolDelegateFunction(int i)
        {
            return i < 10;
        }

    }
    class ActionClass
    {
        public Action actionFunction;

        public void Start()
        {
            actionFunction = HelloWorld;
        }
        public void End()
        {
            actionFunction = GoodbyeWorld;
        }
        private void HelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        private void GoodbyeWorld()
        {
            Console.WriteLine("Goodbye World!");
        }
    }
    class ActionWithTypeClass
    {
        public Action<int, float> actionFunction;
        public void Start()
        {
            actionFunction = (int i, float f) => { Console.WriteLine("Hello World! " + i + " " + f); };
            //actionFunction = (int i, float f) => { randomFunction(i); };
        }

        private void randomFunction(int i)
        {
            Console.WriteLine("Hello World! " + i);
        }
    }
    class FuncClass
    {
        public Func<bool> funcFunction;
        public void Start()
        {
            funcFunction = () => false;
        }

    }
    class FuncWithResultClass
    {
        public Func<int, bool> funcFunction;
        public void Start()
        {
            funcFunction = (int i) => { return i < 10; };
        }
    }
}
