using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net;
using System.Net.Mail;

//SMTP();
IMAP();

void SMTP()
{
    var client = new SmtpClient("smtp.gmail.com", 587);
    client.EnableSsl = true;

    client.Credentials = new NetworkCredential(
        "fbms.1223@gmail.com",
        "your_google_app_password");

    var message = new MailMessage()
    {
        Subject = "For SMTP Test",
        Body = "Salam. Lorem ipsum dolor sit amet. Ameen."

    };
    message.From = new MailAddress("fbms.1223@gmail.com", "Cadudu açma");
    message.To.Add(new MailAddress("zamanov@itstep.org"));
    message.To.Add(new MailAddress("hemidovaqshin@gmail.com"));

    client.Send(message);
}


void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);

    imapClient.Authenticate(
        "fbms.1223@gmail.com",
        "your_google_app_password"
        );

    var inbox = imapClient.GetFolder("Inbox");

    inbox.Open(FolderAccess.ReadWrite);


    #region Read messages
    //var ids = inbox.Search(SearchQuery.All);

    //foreach(var id in ids)
    //{
    //    Console.WriteLine($"{id} {inbox.GetMessage(id).TextBody}");
    //}
    #endregion

    inbox.SetFlags(new List<int> { 0, 3 }, MessageFlags.Deleted, true);
    inbox.Expunge();

    inbox.Close();

}