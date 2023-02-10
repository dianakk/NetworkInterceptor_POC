using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V109.DevToolsSessionDomains;
using Network = OpenQA.Selenium.DevTools.V109.Network;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class Tests
    {
        protected IWebDriver driver;
        protected DevToolsSessionDomains devToolsSession;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            IDevTools devTools = driver as IDevTools;
            IDevToolsSession session = devTools.GetDevToolsSession();

            devToolsSession = session.GetVersionSpecificDomains<DevToolsSessionDomains>();
            devToolsSession.Network.Enable(new Network.EnableCommandSettings());
        }

        [Given("Set custom header")]
        public void SetAddionalHeaders()
        {
            var extraHeader = new Network.Headers();
            extraHeader.Add("testId", "EXECUTE_HACKED");
            devToolsSession.Network.SetExtraHTTPHeaders(new Network.SetExtraHTTPHeadersCommandSettings()
            {
                Headers = extraHeader
            });
        }

        [When("When Url gets hit")]
        public void WhenTheTwoNumbersAreAdded()
        {
            driver.Url = "https://localhost:7190/";
        }
    }
}