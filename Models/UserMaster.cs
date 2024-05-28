namespace Socialdashboard.Models
{
    public class UserMaster
    {
        public int Id { get; set; } 
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public string userpassword { get; set; }
        public string referencesite { get; set; }
    }

    public class Login
    {
        public string mobileNo { get; set; }

        public string userpassword { get; set; }
    }


    public class UserSocialMediaDetails
    {
        public string userId { get; set; }

        public string facebookLink { get; set; }

        public string instagramLink { get; set; }

        public string twitterLink { get; set; }

        public string OtherLink { get; set; }
        
        public string currentlongitude { get; set; }

        public string currentlatitude { get; set; }

        public string currentLocation { get; set; }
    }
}
