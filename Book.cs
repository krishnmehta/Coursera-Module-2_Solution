
namespace GradeBook{
    class Book{

        public Book(String name){
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade){
            grades.Add(grade);
        }

        public void ShowStatistics(){
            var result = 0.0;
            var highgrade = double.MinValue;
            var lowgrade = double.MaxValue;

            foreach(var number in grades){
                lowgrade = Math.Min(number, lowgrade);
                highgrade = Math.Max(number, highgrade);
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine($"The lowest grade is {lowgrade}");
            Console.WriteLine($"The highest grade is {highgrade}");
            Console.WriteLine($"The average grade is {result:N2}");
        }
        
        private List<double> grades;
        private String name;

    }
}
