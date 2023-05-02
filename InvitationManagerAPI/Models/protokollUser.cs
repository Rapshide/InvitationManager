namespace InvitationManagerAPI.Models
{
    public class protokollUser

    {
        public int Id { get; set; }
        public string email { get; set; } = "szia@mia.com";
        public string telefonszám { get; set; } = "06204062116";
        public string erzekenysegek { get; set; } = "fosok a cukortól";
        public string vallás { get; set; } = "nem eszek birka herét";
        public string fogyatékosság { get; set; } = "nincs lábam";
        public string titulus { get; set; } = "Király";
        public int userType { get; set; } = 1;
        public string ProfilePic { get; set; } = "fosok a cukortól";
        public string utolsóesemény { get; set; }
        public string name { get; set; }
    }
}
