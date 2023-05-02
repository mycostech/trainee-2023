namespace ToDoAPI.Data
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }

        public DateTime ExpDate { get; set; }
    }
}
