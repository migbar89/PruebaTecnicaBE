using AppUsers.Dominio.Exceptions;

public interface IMailServices
{
    public Task SendEmailGmail(String email, String subject, String message);


}