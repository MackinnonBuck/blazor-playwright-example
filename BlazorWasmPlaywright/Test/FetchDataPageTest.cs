using Microsoft.Playwright;
using Test.Infrastructure;

namespace BlazorWasmPlaywright.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class FetchDataPageTest : BlazorTest
{
    [Test]
    public async Task WeatherForecastTable_LoadsAndDisplaysData_OnPageInitialization()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GetByRole(AriaRole.Link, new() { Name = "Fetch data" }).ClickAsync();

        await Page.WaitForSelectorAsync("h1 >> text=Weather forecast");

        await Page.WaitForSelectorAsync("table>tbody>tr");

        Assert.That(await Page.Locator("p+table>tbody>tr").CountAsync(), Is.EqualTo(5));
    }
}
