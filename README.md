This solution represents an example on how we can intercept all requests made from browser to inject an extra header.
The solution consists of 2 project:

  * NetworkInterceptor_POC -  an MVC web application
  * SpecFlowTests -  specflow test project

In order to see the demo we need to open the solution in 2 different VS instances. 
In the first instance run the NetworkInterceptor_POC and put a breakpoint on TestHeaderInterception method in Controllers > HomeController. 
In the secnd VS instance just run the only testcase under SpecFlowTests project. 
It should hit the breakpoint in the first VS instance and the testIds variable will be holding the injected extra header.
