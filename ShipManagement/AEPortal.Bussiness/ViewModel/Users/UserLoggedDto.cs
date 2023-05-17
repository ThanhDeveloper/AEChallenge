namespace AEPortal.Bussiness.ViewModel.Users;

public class UserLoggedDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public string AccessToken { get; internal set; }
}