using BlazorServerPlaywright.Test.Infrastructure;
using Microsoft.Playwright;

namespace BlazorServerPlaywright.Test;

[TestFixture]
public class CounterPageTest : BlazorTest
{
    [Test]
    public async Task Count_Increments_WhenButtonIsClicked()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri, new() { WaitUntil = WaitUntilState.NetworkIdle });

        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Status)).ToHaveTextAsync("Current count: 1");
    }
}
