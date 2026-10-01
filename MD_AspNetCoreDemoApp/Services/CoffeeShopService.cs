using MD_AspNetCoreDemoApp.Interfaces;

namespace MD_AspNetCoreDemoApp.Services
{
    public class CoffeeService : ISingletonCoffee , IScopedCoffee , ITransientCoffee
    {

        private readonly string _coffeId;

        public CoffeeService()
        {
            _coffeId = Guid.NewGuid().ToString();
        }

        public string GetCoffeeID()
        {
            return _coffeId;
        }

    }
}
