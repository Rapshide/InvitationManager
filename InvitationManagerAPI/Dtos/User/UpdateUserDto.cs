namespace InvitationManagerAPI.Dtos.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string telefonszám { get; set; }
        public string erzekenysegek { get; set; }
        public string vallás { get; set; }
        public string fogyatékosság { get; set; }
        public string titulus { get; set; }
        public int userType { get; set; }
        public string ProfilePic { get; set; }
        public string utolsóesemény { get; set; }
        public string name { get; set; }
    }
}
