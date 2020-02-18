namespace web_test_api.Model
{
   public class UserRequest
    {
        public string Name { get; set; }
        public string Username { get; set; }
        
    }

    public class User : UserRequest
    {
        public int Id { get; set; }
    }
    
}