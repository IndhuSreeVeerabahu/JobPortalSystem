using Job_Portal_System.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;

namespace Job_Portal_System.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string connection;
        public AdminRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("Job_Portal_API");
        }
        public List<UserModel> GetUser()
        {
            List<UserModel> list = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
               // try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Admin.SPS_ListOfUsers", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserModel um = new UserModel();
                                um.FirstName = reader["FirstName"].ToString();
                                um.LastName = reader["LastName"].ToString();
                                um.DOB = Convert.ToDateTime(reader["DOB"]).Date;
                                um.Email = reader["Email"].ToString();
                                um.Gender = reader["Gender"].ToString();
                                um.MobNo = reader["MobNo"].ToString();
                                um.Username = reader["Username"].ToString();
                                um.Password = reader["Password"].ToString();
                                um.Experience = Convert.ToInt32(reader["Experience"]);
                                um.State = reader["State"].ToString();
                                um.City = reader["City"].ToString();
                                um.Address = reader["Address"].ToString();
                                um.CGPA = Convert.ToInt32(reader["CGPA"]);
                                um.Major = reader["Major"].ToString();
                                um.Degree = reader["Degree"].ToString();
                                um.University = reader["University"].ToString();
                                um.Graduation = reader["Graduation"].ToString();
                                um.Skills = reader["Skills"].ToString();
                                um.ProfilePic = (byte[])reader["ProfilePic"];
                                um.Resume = (byte[])reader["Resume"];
                                um.CreatedBy = reader["CreatedBy"].ToString();
                                um.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]).Date;
                                um.UpdatedBy = reader["UpdatedBy"].ToString();         
                                um.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]).Date;
                                
                                list.Add(um);

                            }
                            reader.Close();
                        }
                    }


                }
               /* catch
                {
                    conn.Close();
                }
                finally { conn.Close(); }*/
                return list;
            }
        }
        public List<HRModel> GetHR()
        {
            List<HRModel> list = new List<HRModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Admin.SPS_ListOfHR", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HRModel hm = new HRModel();
                                hm.Name = reader["Name"].ToString();
                                hm.Email = reader["Email"].ToString();
                                hm.Username = reader["Username"].ToString();
                                hm.Password = reader["Password"].ToString();
                                hm.Mob_No = reader["MobNo"].ToString();
                                hm.Company_Name = reader["CompanyName"].ToString();
                                hm.Company_Email = reader["CompanyEmail"].ToString();
                                hm.Company_Mob_No = reader["CompanyMobNo"].ToString();
                                hm.Company_Website = reader["CompanyWebsite"].ToString();
                                hm.Company_Logo = (byte[])reader["CompanyLogo"];
                                hm.CreatedBy = reader["CreatedBy"].ToString();
                                hm.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]).Date;
                                hm.UpdatedBy = reader["UpdatedBy"].ToString();
                                hm.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]).Date;
                                list.Add(hm);

                            }
                            reader.Close();
                        }
                    }


                }
                catch
                {
                    conn.Close();
                }
                finally { conn.Close(); }
                return list;
            }
        }
        public List<JobModel> GetJob()
        {
            List<JobModel> list = new List<JobModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Admin.SPS_ListOfJobs", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                JobModel jm = new JobModel();
                                //jm.Job_ID = Convert.ToInt64(reader["JobId"]);
                                //jm.HR_ID = Convert.ToInt64(reader["HRId"]);
                                jm.Title = reader["Title"].ToString();
                                jm.Description = reader["Description"].ToString();
                                jm.Req_Skills = reader["ReqSkills"].ToString();
                                jm.Location = reader["Location"].ToString();
                                jm.Salary = Convert.ToInt32(reader["Salary"]);
                                jm.vacancy = Convert.ToInt32(reader["Vacancy"]);
                                jm.Opening = Convert.ToDateTime(reader["Opening"]).Date;
                                jm.Deadline = Convert.ToDateTime(reader["Deadline"]).Date;
                                list.Add(jm);

                            }
                            reader.Close();
                        }
                    }


                }
                catch
                {
                    conn.Close();
                }
                finally { conn.Close(); }
                return list;
            }

            throw new NotImplementedException();
        }
        public List<AppliedDetailsModel> get()
        {
            List<AppliedDetailsModel> list = new List<AppliedDetailsModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Admin.SPS_ViewAppliedDetails", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AppliedDetailsModel am = new AppliedDetailsModel();
                                am.UserId = Convert.ToInt64(reader["UserId"]);
                                am.UserAppliedOn = Convert.ToDateTime(reader["UserAppliedOn"]).Date;
                                am.HRId = Convert.ToInt64(reader["HRId"]);
                                am.JobId = Convert.ToInt64(reader["JobId"]);
                                am.RecruitmentStatus = reader["RecruitmentStatus"].ToString();
                                list.Add(am);

                            }
                            reader.Close();
                        }
                    }


                }
                catch
                {
                    conn.Close();
                }
                finally { conn.Close(); }
                return list;
            }

           // throw new NotImplementedException();
        }

        public void Insert(UserModel userModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                //try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SPI_InsertUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", userModel.LastName);
                        cmd.Parameters.AddWithValue("@DOB", userModel.DOB);
                        cmd.Parameters.AddWithValue("@Email", userModel.Email);
                        cmd.Parameters.AddWithValue("@Gender", userModel.Gender);
                        cmd.Parameters.AddWithValue("@MobNo", userModel.MobNo);
                        cmd.Parameters.AddWithValue("@Username", userModel.Username);
                        cmd.Parameters.AddWithValue("Password", userModel.Password);
                        cmd.Parameters.AddWithValue("@Experience", userModel.Experience);
                        cmd.Parameters.AddWithValue("@State", userModel.State);
                        cmd.Parameters.AddWithValue("@City", userModel.City);
                        cmd.Parameters.AddWithValue("@Address", userModel.Address);
                        cmd.Parameters.AddWithValue("@CGPA", userModel.CGPA);
                        cmd.Parameters.AddWithValue("@Major", userModel.Major);
                        cmd.Parameters.AddWithValue("@Degree", userModel.Degree);
                        cmd.Parameters.AddWithValue("@University", userModel.University);
                        cmd.Parameters.AddWithValue("@Graduation", userModel.Graduation);
                        cmd.Parameters.AddWithValue("@Skills", userModel.Skills);
                        cmd.Parameters.AddWithValue("@ProfilePic", userModel.ProfilePic);
                        cmd.Parameters.AddWithValue("@Resume", userModel.Resume);
                        cmd.Parameters.AddWithValue("@CreatedBy", userModel.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", userModel.CreatedOn);
                        cmd.Parameters.AddWithValue("@UpdatedBy", userModel.UpdatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedOn", userModel.UpdatedOn);
                        cmd.ExecuteReader();
                        conn.Close();
                    }


                }
               /* catch 
                {
                    conn.Close();
                }
                finally { conn.Close(); }*/

            }
            // throw new NotImplementedException();
        }

        public void Insert(HRModel hrModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                //try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Admin.SPI_InsertHR", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", hrModel.Name);
                        cmd.Parameters.AddWithValue("@Email", hrModel.Email);
                        cmd.Parameters.AddWithValue("@Username", hrModel.Username);
                        cmd.Parameters.AddWithValue("Password", hrModel.Password);
                        cmd.Parameters.AddWithValue("@Mob_No", hrModel.Mob_No);
                        cmd.Parameters.AddWithValue("@CompanyName", hrModel.Company_Name);
                        cmd.Parameters.AddWithValue("@CompanyEmail", hrModel.Company_Email);
                        cmd.Parameters.AddWithValue("@CompanyMobNo", hrModel.Company_Mob_No);
                        cmd.Parameters.AddWithValue("@CompanyWebsite", hrModel.Company_Website);
                        cmd.Parameters.AddWithValue("@CompanyLogo", hrModel.Company_Logo);
                        cmd.Parameters.AddWithValue("@CreatedBy", hrModel.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", hrModel.CreatedOn);
                        cmd.Parameters.AddWithValue("@UpdatedBy", hrModel.UpdatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedOn", hrModel.UpdatedOn);
                        cmd.ExecuteReader();
                        conn.Close();
                    }


                }
               /* catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { conn.Close(); }*/

            }


            //throw new NotImplementedException();
        }

        public void Update(UserModel userModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
               // try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SPU_UpdateUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", userModel.LastName);
                        cmd.Parameters.AddWithValue("@DOB", userModel.DOB);
                        cmd.Parameters.AddWithValue("@Email", userModel.Email);
                        cmd.Parameters.AddWithValue("@Gender", userModel.Gender);
                        cmd.Parameters.AddWithValue("@MobNo", userModel.MobNo);
                        cmd.Parameters.AddWithValue("@Username", userModel.Username);
                        cmd.Parameters.AddWithValue("Password", userModel.Password);
                        cmd.Parameters.AddWithValue("@Experience", userModel.Experience);
                        cmd.Parameters.AddWithValue("@State", userModel.State);
                        cmd.Parameters.AddWithValue("@City", userModel.City);
                        cmd.Parameters.AddWithValue("@Address", userModel.Address);
                        cmd.Parameters.AddWithValue("@CGPA", userModel.CGPA);
                        cmd.Parameters.AddWithValue("@Major", userModel.Major);
                        cmd.Parameters.AddWithValue("@Degree", userModel.Degree);
                        cmd.Parameters.AddWithValue("@University", userModel.University);
                        cmd.Parameters.AddWithValue("@Graduation", userModel.Graduation);
                        cmd.Parameters.AddWithValue("@Skills", userModel.Skills);
                        cmd.Parameters.AddWithValue("@ProfilePic", userModel.ProfilePic);
                        cmd.Parameters.AddWithValue("@Resume", userModel.Resume);
                        cmd.Parameters.AddWithValue("@CreatedBy", userModel.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", userModel.CreatedOn);
                        cmd.Parameters.AddWithValue("@UpdatedBy", userModel.UpdatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedOn", userModel.UpdatedOn);
                        cmd.ExecuteReader();
                        conn.Close();
                    }


                }
                /*catch 
                {
                    conn.Close();
                    
                }
                finally { conn.Close(); }*/

            }
            //throw new NotImplementedException();
        }

        public void Update(HRModel hrModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
               // try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SPU_UpdateHR", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", hrModel.Name);
                        cmd.Parameters.AddWithValue("@Email", hrModel.Email);
                        cmd.Parameters.AddWithValue("@Username", hrModel.Username);
                        cmd.Parameters.AddWithValue("Password", hrModel.Password);
                        cmd.Parameters.AddWithValue("@Mob_No", hrModel.Mob_No);
                        cmd.Parameters.AddWithValue("@CompanyName", hrModel.Company_Name);
                        cmd.Parameters.AddWithValue("@CompanyEmail", hrModel.Company_Email);
                        cmd.Parameters.AddWithValue("@CompanyMobNo", hrModel.Company_Mob_No);
                        cmd.Parameters.AddWithValue("@CompanyWebsite", hrModel.Company_Website);
                        cmd.Parameters.AddWithValue("@CompanyLogo", hrModel.Company_Logo);
                        cmd.Parameters.AddWithValue("@CreatedBy", hrModel.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", hrModel.CreatedOn);
                        cmd.Parameters.AddWithValue("@UpdatedBy", hrModel.UpdatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedOn", hrModel.UpdatedOn);
                        cmd.ExecuteReader();
                        conn.Close();
                    }


                }
               /* catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { conn.Close(); }*/

            }

        }
    }
}
