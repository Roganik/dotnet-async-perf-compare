using Async.LoadTest;

var test = new RunNBomberCommand();
test.Execute(
    scenarioName: "http_getsync_scenario_100",
    url: "http://localhost:5292/WeatherForecast/GetSync",
    rate: 100);

await Task.Delay(5000); // cooldown

test.Execute(
    scenarioName: "http_getsync_scenario_400",
    url: "http://localhost:5292/WeatherForecast/GetSync",
    rate: 400);

await Task.Delay(10000); // cooldown

test.Execute(
    scenarioName: "http_getasync_scenario_100",
    url: "http://localhost:5292/WeatherForecast/GetAsync",
    rate: 100);

await Task.Delay(5000); // cooldown

test.Execute(
    scenarioName: "http_getasync_scenario_400",
    url: "http://localhost:5292/WeatherForecast/GetAsync",
    rate: 400);

await Task.Delay(5000); // cooldown

test.Execute(
    scenarioName: "http_getasync_scenario_1000",
    url: "http://localhost:5292/WeatherForecast/GetAsync",
    rate: 1000);