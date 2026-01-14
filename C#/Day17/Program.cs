using System;
using System.Reflection;

namespace MyApp.Models
{
    // ---------------------------------------------
    // Sample class used for Reflection demonstration
    // ---------------------------------------------
    class Employee
    {
        // Public property
        // Can be accessed normally and via Reflection
        public string Name { get; set; }

        // Private field
        // Cannot be accessed directly outside the class
        // Can be accessed using Reflection with BindingFlags
        private int _salary = 30000;

        // Parameterless constructor
        // Called when object is created without arguments
        public Employee()
        {
            Console.WriteLine("Employee object created (default constructor)");
        }

        // Parameterized constructor
        // Called when object is created with name and salary
        public Employee(string name, int salary)
        {
            Name = name;
            _salary = salary;
            Console.WriteLine("Employee object created (parameterized constructor)");
        }

        // Public method
        // Will be invoked dynamically using MethodInfo
        public void Work()
        {
            Console.WriteLine("Employee is working");
        }

        // Method with parameter
        // Used to demonstrate ParameterInfo
        public void UpdateSalary(int amount)
        {
            _salary = amount;
        }

        // Helper method
        // Used to verify salary changes done via Reflection
        public void ShowSalary()
        {
            Console.WriteLine("Salary: " + _salary);
        }
    }

    class Program
    {
        static void Main()
        {
            
            // 1️⃣ GET THE CURRENTLY EXECUTING ASSEMBLY
           

            // Gets the assembly (.exe) that is currently running
            // Assembly is the container of all classes and metadata
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Prints full assembly information
            Console.WriteLine("Executing Assembly:");
            Console.WriteLine(assembly.FullName);
            Console.WriteLine();

            
            // 2️⃣ LIST ALL CLASSES AND METHODS IN THE ASSEMBLY
            

            // GetTypes() returns all classes, interfaces, structs, etc.
            foreach (Type type in assembly.GetTypes())
            {
                // Prints class name
                Console.WriteLine("Class: " + type.Name);

                // GetMethods() returns all public methods
                foreach (MethodInfo method in type.GetMethods())
                {
                    // Prints method name
                    Console.WriteLine("  Method: " + method.Name);
                }
            }

            Console.WriteLine("\n-----------------------------------\n");

         
            // 3️⃣ GET TYPE OBJECT (ALL POSSIBLE WAYS)
           

            // Way 1: Compile-time
            // No object required
            // Gets metadata of Employee class
            Type type1 = typeof(Employee);

            // Way 2: Runtime using object
            // Object must be created
            Employee emp = new Employee();
            Type type2 = emp.GetType();

            // Way 3: Using fully qualified name
            // Namespace + ClassName as string
            Type type3 = Type.GetType("MyApp.Models.Employee");

            // Display all obtained type names
            Console.WriteLine("Type Information:");
            Console.WriteLine(type1.FullName);
            Console.WriteLine(type2.FullName);
            Console.WriteLine(type3.FullName);
            Console.WriteLine();

          
            // 4️⃣ METHODINFO - FIND & INVOKE METHOD
           

            // GetMethod("Work") finds metadata of Work() method
            MethodInfo workMethod = type1.GetMethod("Work");

            // Invoke() executes the method dynamically
            // emp -> object on which method is called
            // null -> method has no parameters
            workMethod.Invoke(emp, null);

            Console.WriteLine();

            
            // 5️⃣ PROPERTYINFO - SET PROPERTY VALUE
            

            // GetProperty("Name") finds Name property metadata
            PropertyInfo prop = type1.GetProperty("Name");

            // SetValue() assigns value dynamically at runtime
            prop.SetValue(emp, "Jyoti");

            // Verifying property value
            Console.WriteLine("Employee Name: " + emp.Name);
            Console.WriteLine();

           
            // 6️⃣ FIELDINFO - ACCESS PRIVATE FIELD USING BINDINGFLAGS
            

            // GetField() is used to access fields
            // BindingFlags.NonPublic -> include private fields
            // BindingFlags.Instance -> field belongs to object, not the class itself.
            FieldInfo field = type1.GetField(
                "_salary",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            // Display original salary
            Console.WriteLine("Original Salary:");
            emp.ShowSalary();

            // GetValue() reads value of private field
            int currentSalary = (int)field.GetValue(emp);
            Console.WriteLine("Salary via Reflection: " + currentSalary);

            // SetValue() modifies private field value
            field.SetValue(emp, 50000);

            // Verify updated salary
            Console.WriteLine("Updated Salary:");
            emp.ShowSalary();

            Console.WriteLine();

        
            // 7️⃣ CONSTRUCTORINFO - PARAMETERLESS CONSTRUCTOR
            

            // Type.EmptyTypes means constructor with no parameters
            ConstructorInfo ctor1 = type1.GetConstructor(Type.EmptyTypes);

            // Invoke() creates object dynamically
            object obj1 = ctor1.Invoke(null);

            Console.WriteLine();

            
            // 8️⃣ CONSTRUCTORINFO - PARAMETERIZED CONSTRUCTOR || represents metadata about constructors 
            

            // new Type[] specifies constructor parameter types
            ConstructorInfo ctor2 = type1.GetConstructor(
                new Type[] { typeof(string), typeof(int) }
            );

            // Passing constructor arguments using object array
            object obj2 = ctor2.Invoke(new object[] { "sakshi", 60000 });

            Console.WriteLine();

           
            // 9️⃣ PARAMETERINFO - GET METHOD PARAMETERS
           

            // Get method metadata
            MethodInfo updateMethod = type1.GetMethod("UpdateSalary");

            // GetParameters() returns all parameters of method
            ParameterInfo[] parameters = updateMethod.GetParameters();

            // Display parameter details
            Console.WriteLine("Parameters of UpdateSalary method:");
            foreach (ParameterInfo p in parameters)
            {
                Console.WriteLine(
                    "Name: " + p.Name +
                    ", Type: " + p.ParameterType +
                    ", Position: " + p.Position
                );
            }

            Console.WriteLine("\nProgram completed successfully");
        }
    }
}