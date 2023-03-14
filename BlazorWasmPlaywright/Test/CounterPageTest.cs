using Microsoft.Playwright;
using Test.Infrastructure;

namespace BlazorWasmPlaywright.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CounterPageTest : BlazorTest
{
    [Test]
    public async Task Count_Increments_WhenButtonIsClicked()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Status)).ToHaveTextAsync("Current count: 1");
    }
}
