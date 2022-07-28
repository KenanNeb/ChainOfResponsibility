
public interface IProblemHandler
{
    void HandleRequest(int problemID);
}

public class Employee : IProblemHandler
{
    IProblemHandler nextHandler;

    public Employee(IProblemHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public void HandleRequest(int problemID)
    {
        if (problemID > 0 && problemID <= 10)
        {
            Console.WriteLine("Employee handles the request");
        }
        else if (this.nextHandler != null)
        {
            this.nextHandler.HandleRequest(problemID);
        }
    }
}

public class Manager : IProblemHandler
{
    IProblemHandler nextHandler;

    public Manager(IProblemHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public void HandleRequest(int problemID)
    {
        if (problemID >= 11 && problemID <= 20)
        {
            Console.WriteLine("Manager handles the request");
        }
        else if (this.nextHandler != null)
        {
            this.nextHandler.HandleRequest(problemID);
        }
    }
}

public class TechArch : IProblemHandler
{
    IProblemHandler nextHandler;

    public TechArch(IProblemHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public void HandleRequest(int problemID)
    {
        if (problemID >= 21)
        {
            Console.WriteLine("Technical Architect handles the request");
        }
        else if (this.nextHandler != null)
        {
            this.nextHandler.HandleRequest(problemID);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TechArch techArch = new TechArch(null);
        Manager manager = new Manager(techArch);
        Employee employee = new Employee(manager);

        employee.HandleRequest(45); //Request will handle by Tech Arch
        employee.HandleRequest(15); //Request will handle by Manager
        employee.HandleRequest(8); //Request will handle by Employee
    }
}
