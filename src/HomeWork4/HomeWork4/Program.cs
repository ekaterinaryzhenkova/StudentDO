using CLient;

namespace HomeWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientCommand command1 = new ClientCommand();
            command1.AddClient("Test2 Test2", "89114013040");

            MasseurCommand command2 = new MasseurCommand();
            command2.AddMasseur("Test2 Test2", "Thai massage");

            SessionCommand command3 = new();
            command3.AddSession(Guid.Parse("2CA5A929-EDD1-4D88-8A22-6384CA7F068F"), Guid.Parse("F0003667-FCBC-4ED2-A2E3-97805AD33119"), DateTime.UtcNow);

            ReviewCommand command4 = new ReviewCommand();
            command4.AddReview(Guid.Parse("2CA5A929-EDD1-4D88-8A22-6384CA7F068F"), Guid.Parse("F0003667-FCBC-4ED2-A2E3-97805AD33119"), 5, "That was nice");
        }
    }
}