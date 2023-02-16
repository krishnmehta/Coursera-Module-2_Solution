public void Task2()
{
    var result = from emp in employeeList
                 where emp.Age > 0
                 orderby emp.Age descending
                 select emp;

    var oldestTwoEmployees = result.Take(2);

    var monthlySalaryDetails = from emp in oldestTwoEmployees
                               join sal in salaryList on emp.EmployeeID equals sal.EmployeeID
                               where sal.Type == SalaryType.Monthly
                               group sal by new { emp.EmployeeFirstName, emp.EmployeeLastName } into g
                               select new
                               {
                                   Name = g.Key.EmployeeFirstName + " " + g.Key.EmployeeLastName,
                                   TotalMonthlySalary = g.Sum(s => s.Amount)
                               }
                               into tempResult
                               select tempResult;

    Console.WriteLine("Task 2: Details of 2 oldest employees with their total monthly salary:");
    foreach (var item in oldestTwoEmployees)
    {
        Console.WriteLine($"Employee Name: {item.EmployeeFirstName} {item.EmployeeLastName}");
        Console.WriteLine($"Age: {item.Age}");
        Console.WriteLine($"Total Monthly Salary: {monthlySalaryDetails.FirstOrDefault(x => x.Name == (item.EmployeeFirstName + " " + item.EmployeeLastName)).TotalMonthlySalary}");
        Console.WriteLine();
    }
}