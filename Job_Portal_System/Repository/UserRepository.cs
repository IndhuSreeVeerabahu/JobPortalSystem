using Job_Portal_System.Model;
using System.Data.SqlClient;

namespace Job_Portal_System.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string connection;
        public UserRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("Job_Portal_API");
        }
        public List<AppliedDetailsModel> GetApplied(long userId)
        {
            List<AppliedDetailsModel> list = new List<AppliedDetailsModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
               // try
              //  {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("User.SPS_ViewAppliedDetails", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@UserId",userId);
                        //cmd.Parameters.AddWithValue("@UserAppliedOn", UserAppliedOn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AppliedDetailsModel am = new AppliedDetailsModel();
                                am.UserId = Convert.ToInt64(reader["UserId"]);
                                am.UserAppliedOn = Convert.ToDateTime(reader["UserAppliedOn"]).Date;
                                am.RecruitmentStatus = reader["RecruitmentStatus"].ToString(); 
                                am.HRId = Convert.ToInt64(reader["HRId"]);
                                am.JobId = Convert.ToInt64(reader["JobId"]);
                             //   am.RecruitmentStatus = reader["RecruitmentStatus"].ToString();
                                list.Add(am);

                            }
                            reader.Close();
                        }
                    }


              //  }
               /* catch
                {
                    //conn.Close();
                }
                finally { conn.Close(); }*/
                return list;
            }
            //throw new NotImplementedException();
        }

        public List<JobModel> GetJob()
        {
            List<JobModel> list = new List<JobModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("User.SPS_JobList", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                JobModel jm = new JobModel();
                                //jm.Job_ID = Convert.ToInt64(reader["JobId"]);
                                //jm.HR_ID = Convert.ToInt64(reader["HRId"]);
                                jm.Title= reader["Title"].ToString();
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

        public void Insert(UserModel userModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                //try
                //{
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
        }


               /* }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { conn.Close(); }

            }*/

            //throw new NotImplementedException();

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
    }
}
