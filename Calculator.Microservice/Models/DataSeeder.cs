namespace Calculator.Microservice.Models
{
    public class DataSeeder
    {
        private readonly CalculatorDbContext calculatorDbContext;

        public DataSeeder(CalculatorDbContext calculatorDbContext)
        {
            this.calculatorDbContext = calculatorDbContext;
        }

        public void Seed()
        {
            if (!calculatorDbContext.Calculator.Any())
            {
                var calculator = new Calculator()
                {
                    Totalscore = 19
                };

                calculatorDbContext.Calculator.Add(calculator);
                calculatorDbContext.SaveChanges();
            }
        }
    }
}
