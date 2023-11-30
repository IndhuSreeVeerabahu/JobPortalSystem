using Job_Portal_System.Model;
using System.Data.SqlClient;

namespace Job_Portal_System.Repository
{
    public class HRRepository : IHRRepository
    {
        private readonly string connection;
        public HRRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("Job_Portal_API");
        }
        public List<AppliedDetailsModel> Get(long HRId)
        {
            List<AppliedDetailsModel> list = new List<AppliedDetailsModel>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
               // try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("HR.SPS_ViewAppliedDetails", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HRID", HRId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AppliedDetailsModel am = new AppliedDetailsModel();
                                am.UserId = Convert.ToInt64(reader["UserId"]);
                                am.UserAppliedOn = Convert.ToDateTime(reader["UserAppliedOn"]).Date;
                                //am.RecruitmentStatus = reader["RecruitmentStatus"].ToString();
                                am.HRId = Convert.ToInt64(reader["HRID"]);
                                am.JobId = Convert.ToInt64(reader["JobId"]);
                                am.RecruitmentStatus = reader["RecruitmentStatus"].ToString();
                                list.Add(am);

                            }
                            reader.Close();
                        }
                    }


                }
               /* catch
                {
                   // conn.Close();
                }
                finally { conn.Close(); }*/
                return list;
            }

            //throw new NotImplementedException();
        }

        public void Insert(JobModel jobModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                //try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("HR.SPI_InsertJob", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        // cmd.Parameters.AddWithValue("@JobId", jobModel.Job_ID);
                        cmd.Parameters.AddWithValue("@HRID", jobModel.HR_ID);
                        cmd.Parameters.AddWithValue("@Title", jobModel.Title);
                        cmd.Parameters.AddWithValue("@JobCode", jobModel.JobCode);
                        cmd.Parameters.AddWithValue("@Description", jobModel.Description);
                        cmd.Parameters.AddWithValue("@Req_Skills", jobModel.Req_Skills);
                        cmd.Parameters.AddWithValue("@Location", jobModel.Location);
                        cmd.Parameters.AddWithValue("@Salary", jobModel.Salary);
                        cmd.Parameters.AddWithValue("@Type", jobModel.Type);
                        cmd.Parameters.AddWithValue("@Role", jobModel.Role);
                        cmd.Parameters.AddWithValue("@Vacancy", jobModel.vacancy);
                        cmd.Parameters.AddWithValue("@Opening", jobModel.Opening);
                        cmd.Parameters.AddWithValue("@Deadline", jobModel.Deadline);
                        cmd.ExecuteReader();
                        conn.Close();
                    }


                }
               /* catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { conn.Close(); }*/
                // throw new NotImplementedException();
            }

            //throw new NotImplementedException();
        }

        public void UpdateHR(HRModel hrModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                //try
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

                // throw new NotImplementedException();
            }
            //throw new NotImplementedException();
        }

        public void UpdateJob(JobModel jobModel)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                //try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("HR.SPU_UpdateJob", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HRID", jobModel.HR_ID);
                        cmd.Parameters.AddWithValue("@Title", jobModel.Title);
                        cmd.Parameters.AddWithValue("@JobCode", jobModel.JobCode);
                        cmd.Parameters.AddWithValue("@Description", jobModel.Description);
                        cmd.Parameters.AddWithValue("@Req_Skills", jobModel.Req_Skills);
                        cmd.Parameters.AddWithValue("@Location", jobModel.Location);
                        cmd.Parameters.AddWithValue("@Salary", jobModel.Salary);
                        cmd.Parameters.AddWithValue("@Type", jobModel.Type);
                        cmd.Parameters.AddWithValue("@Role", jobModel.Role);
                        cmd.Parameters.AddWithValue("@Vacancy", jobModel.vacancy);
                        cmd.Parameters.AddWithValue("@Opening", jobModel.Opening);
                        cmd.Parameters.AddWithValue("@Deadline", jobModel.Deadline);
                        cmd.ExecuteReader();
                        conn.Close();
                    }


                }
               /* catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { conn.Close(); }*/
                // throw new NotImplementedException();
            }

            //throw new NotImplementedException();
        }
    }
}
