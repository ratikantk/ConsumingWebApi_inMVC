namespace EmployeeDataMVC.Helper
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44350/api/");
            return client;
        }
    }
}
