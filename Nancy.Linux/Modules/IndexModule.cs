using Nancy;

namespace Nancy.Linux.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return "Hello world";
            };
        }
    }
}