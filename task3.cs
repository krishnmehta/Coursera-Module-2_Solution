public void Task3()
{
    var employees = employeeList.Where(e => e.Age > 30).Select(e => e.EmployeeID);
    var salaries = salaryList.Where(s => employees.Contains(s.EmployeeID));

    var monthlyMean = salaries.Where(s => s.Type == SalaryType.Monthly).Average(s => s.Amount);
    var performanceMean = salaries.Where(s => s.Type == SalaryType.Performance).Average(s => s.Amount);
    var bonusMean = salaries.Where(s => s.Type == SalaryType.Bonus).Average(s => s.Amount);

    Console.WriteLine("Mean Monthly Salary: {0}", monthlyMean);
    Console.WriteLine("Mean Performance Salary: {0}", performanceMean);
    Console.WriteLine("Mean Bonus Salary: {0}", bonusMean);
}
