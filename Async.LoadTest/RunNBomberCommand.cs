namespace Async.LoadTest;

using NBomber.CSharp;
using NBomber.Http.CSharp;

public class RunNBomberCommand
{
    public void Execute(string scenarioName, string url, int rate)
    {
        using var httpClient = new HttpClient();

        var scenario = Scenario.Create(scenarioName, async context =>
            {
                var request =
                    Http.CreateRequest("GET", url)
                        .WithHeader("Accept", "text/plain");

                var response = await Http.Send(httpClient, request);

                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: rate,
                    interval: TimeSpan.FromSeconds(1),
                    during: TimeSpan.FromSeconds(20))
            );

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
}