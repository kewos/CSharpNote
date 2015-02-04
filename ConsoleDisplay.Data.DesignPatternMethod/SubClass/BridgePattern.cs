using System;
using System.Collections;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    class BusinessObject
    {
        // Fields
        private DataObject dataObject;
        protected string group;

        // Constructors
        public BusinessObject( string group )
        {
            this.group = group;
        }

        // Properties
        public DataObject DataObject
        {
            set{ dataObject = value; }
            get{ return dataObject; }
        }

        // Methods
        virtual public void Next()
        { dataObject.NextRecord(); }

        virtual public void Prior()
        { dataObject.PriorRecord(); }

        virtual public void New( string name )
        { dataObject.NewRecord( name ); }

        virtual public void Delete( string name )
        { dataObject.DeleteRecord( name ); }

        virtual public void Show()
        { dataObject.ShowRecord(); }

        virtual public void ShowAll()
        {
            Console.WriteLine( "Customer Group: {0}", group );
            dataObject.ShowAllRecords();
        }
    }

    // "RefinedAbstraction"
    class CustomersBusinessObject : BusinessObject
    {
        // Constructors
        public CustomersBusinessObject( string group ) : base( group ){}

        // Methods
        override public void ShowAll()
        {
            // Add separator lines
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            base.ShowAll();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }

    // "Implementor"
    abstract class DataObject
    {
      // Methods
      abstract public void NextRecord();
      abstract public void PriorRecord();
      abstract public void NewRecord( string name );
      abstract public void DeleteRecord( string name );
      abstract public void ShowRecord();
      abstract public void ShowAllRecords();
    }

    // "ConcreteImplementor"
    class CustomersDataObject : DataObject
    {
        // Fields
        private ArrayList customers = new ArrayList();
        private int current = 0;

        // Constructors
        public CustomersDataObject()
        {
            // Loaded from a database
            customers.Add("Jim Jones");
            customers.Add("Samual Jackson");
            customers.Add("Allen Good");
            customers.Add("Ann Stills");
            customers.Add("Lisa Giolani");
        }

        // Methods
        public override void NextRecord()
        {
            if (current <= customers.Count - 1)
                current++;
        }

        public override void PriorRecord()
        {
            if (current > 0)
                current--;
        }

        public override void NewRecord(string name)
        {
            customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            customers.Remove(name);
        }

        public override void ShowRecord()
        {
            Console.WriteLine(customers[current]);
        }

        public override void ShowAllRecords()
        {
            foreach (string name in customers)
                Console.WriteLine(" " + name);
        }
    }
}
