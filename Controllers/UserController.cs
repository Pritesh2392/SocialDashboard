using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Socialdashboard.DbModel;
using Socialdashboard.Models;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Text.Json.Nodes;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Socialdashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly IConfiguration _config;
        public readonly SocialDashboardContext _context;

        //string constr = "Data Source=ACER-PC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        string constr = @"Data Source=ACER-PC;Integrated Security=True;Initial Catalog=SocialDashboard;Trust Server Certificate=True";
        public UserController (IConfiguration config,SocialDashboardContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        [Route("Create_User")]
        public ResponseVM Create_User(UserMaster objuser)
        {
            ResponseVM response = new ResponseVM();
            if(objuser.firstname==null || objuser.firstname==string.Empty)
            {
                response.Message = "First name is required.";
                response.StatusCode = 401;
                return response;
            }
            else if(objuser.lastname==null || objuser.lastname==string.Empty)
            {
                response.Message = "Last name is required.";
                response.StatusCode = 401;
                return response;
            }
            else if(objuser.mobile==null || objuser.mobile==string.Empty)
            {
                response.Message = "Mobile no is required.";
                response.StatusCode = 401;
                return response;
            }
            else if(objuser.userpassword==null || objuser.userpassword==string.Empty)
            {
                response.Message = "Password is required.";
                response.StatusCode = 401;
                return response;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO TblUsers ([FirstName],[LastName],[MobileNo],[Password],[RoleID]) VALUES (@Value1, @Value2, @Value3,@Value4,@Value5)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Assuming you have values to insert
                        cmd.Parameters.AddWithValue("@Value1", objuser.firstname);
                        cmd.Parameters.AddWithValue("@Value2", objuser.lastname);
                        cmd.Parameters.AddWithValue("@Value3", objuser.mobile);
                        cmd.Parameters.AddWithValue("@Value4", objuser.userpassword);
                        cmd.Parameters.AddWithValue("@Value5", 2);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            response.Message = "User created successfully.";
                            response.StatusCode = 200;
                            response.Data = objuser;
                        }
                        else
                        {
                            response.Message = "Something went wrong";
                            response.StatusCode = 500;
                            response.Data = objuser;
                        }
                    }
                }
                
                return response;
            }
            
        }


        [HttpPost]
        [Route("Login_User")]
        public ResponseVM Login_User(Login objlogin)
        {
            ResponseVM response = new ResponseVM();
            if(objlogin == null)
            {
                response.Message = "Invalid Request.";
                response.StatusCode = 401;
                return response;
            }
            else if(objlogin.mobileNo==null || objlogin.mobileNo==string.Empty)
            {
                response.Message = "Mobile no is required.";
                response.StatusCode = 401;
                return response;
            }
            else if(objlogin.userpassword == null || objlogin.userpassword == string.Empty)
            {
                response.Message = "Password is required.";
                response.StatusCode = 401;
                return response;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "SELECT [UserID],[FirstName],[LastName],[MobileNo],[Password],[RoleID]  FROM [TblUsers] WHERE MobileNo = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", objlogin.mobileNo); 
                        cmd.Parameters.AddWithValue("@Password", objlogin.userpassword); 
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(sdr); 

                            if (dataTable.Rows.Count > 0)
                            {
                                string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                                response.Message = "Login successfully.";
                                response.StatusCode = 200;
                                response.Data = json;
                            }
                        }
                    }
                }
                return response;
            }
            
        }


        [HttpPost]
        [Route("Save_SocialMediaDetail")]
        public ResponseVM Save_SocialMediaDetail(UserSocialMediaDetails objsocialmedia)
        {

            ResponseVM response = new ResponseVM();
            if (objsocialmedia == null)
            {
                response.Message = "Invalid Request.";
                response.StatusCode = 401;
                return response;
            }
            else if(objsocialmedia.userId==null|| objsocialmedia.userId==string.Empty)
            {
                response.Message = "User not found.";
                response.StatusCode = 401;
                return response;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO TblUserSocialMediaDetails ([UserID],[FacebookLink],[InstagramLink],[TwitterLink],[OtherLink],[CurrentLocation],[Longitude],[Latitude]) " +
                        "VALUES (@Value1, @Value2, @Value3,@Value4,@Value5,@Value6,@Value7,@Value8)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Assuming you have values to insert
                        cmd.Parameters.AddWithValue("@Value1", objsocialmedia.userId);
                        cmd.Parameters.AddWithValue("@Value2", objsocialmedia.facebookLink);
                        cmd.Parameters.AddWithValue("@Value3", objsocialmedia.instagramLink);
                        cmd.Parameters.AddWithValue("@Value4", objsocialmedia.twitterLink);
                        cmd.Parameters.AddWithValue("@Value5", objsocialmedia.OtherLink);
                        cmd.Parameters.AddWithValue("@Value6", objsocialmedia.currentLocation);
                        cmd.Parameters.AddWithValue("@Value7", objsocialmedia.currentlongitude);
                        cmd.Parameters.AddWithValue("@Value8",objsocialmedia.currentlatitude);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            response.Message = "Social Media Details Save successfully.";
                            response.StatusCode = 200;
                            response.Data = objsocialmedia;
                        }
                        else
                        {
                            response.Message = "Something went wrong";
                            response.StatusCode = 500;
                            response.Data = objsocialmedia;
                        }
                    }
                }
                return response;
            }

        }

        [HttpPost]
        [Route("Get_SocialMediaDetail")]
        public ResponseVM Get_SocialMediaDetail (int UserID=1)
        {
            ResponseVM response = new ResponseVM();
            if (UserID==0)
            {
                response.Message = "User Not Found.";
                response.StatusCode = 401;
                return response;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "SELECT [UserSocialMediaID],[UserID],[FacebookLink],[InstagramLink],[TwitterLink],[OtherLink],[CurrentLocation],[Longitude],[Latitude]  FROM [TblUserSocialMediaDetails] WHERE UserID = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", UserID);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(sdr);

                            if (dataTable.Rows.Count > 0)
                            {
                                string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                                response.Message = "Detail Fetch successfully.";
                                response.StatusCode = 200;
                                response.Data = json;
                            }
                        }
                    }
                }
                return response;
            }
        }


    }
}
