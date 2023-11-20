public class HelloWorldService : IHelloworldService
{
    public string GetHelloWorld()
    {
        return "Hello World!!s!";
    }

        public string GetByeWorld()
    {
        return "god bye!";
    }
}

public interface IHelloworldService
{
    string GetHelloWorld();
    string GetByeWorld();
}