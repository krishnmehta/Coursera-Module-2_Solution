public void Task1()
{
    var result = from emp in employeeList
                 join sal in salaryList on emp.EmployeeID equals sal.EmployeeID
                 group sal by new { emp.EmployeeFirstName, emp.EmployeeLastName } into g
                 select new
                 {
                     Name = g.Key.EmployeeFirstName + " " + g.Key.EmployeeLastName,
                     TotalSalary = g.Sum(s => s.Amount)
                 }
                 into tempResult
                 orderby tempResult.TotalSalary ascending
                 select tempResult;

    Console.WriteLine("Task 1: Total salary of all employees in ascending order:");
    foreach (var item in result)
    {
        Console.WriteLine($"{item.Name}: {item.TotalSalary}");
    }
    Console.WriteLine();
}
