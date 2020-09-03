using Marija_Bozic_Dan_60.DTO;
using Marija_Bozic_Dan_60.Helper;
using Marija_Bozic_Dan_60.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_60.Service
{
    public class ServiceCode
    {
        public List<Gender> GettAllGender()
        {
            List<Gender> genderList = new List<Gender>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllGender";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Gender r = new Gender
                            {
                                GenderId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            genderList.Add(r);
                        }
                        return genderList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Sector> GettAllSectors()
        {
            List<Sector> sectorList = new List<Sector>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllSector";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Sector r = new Sector
                            {
                                SectorId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            sectorList.Add(r);
                        }
                        return sectorList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Location> GettAllLocations()
        {
            List<Location> locationList = new List<Location>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllLocation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Location r = new Location
                            {
                                LocationId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            locationList.Add(r);
                        }
                        return locationList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<UserDTO> GettAllUsers()
        {
            List<UserDTO> userList = new List<UserDTO>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                UserDTO u = new UserDTO();
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllUsers";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            UserDTO r = new UserDTO
                            {
                                UserId = int.Parse(row[0].ToString()),
                                FullName = row[1].ToString(),
                                Date = DateTime.Parse(row[2].ToString()),
                                IDNumber = int.Parse(row[3].ToString()),
                                Jmbg = long.Parse(row[4].ToString()),
                                PhoneNumber = row[5].ToString(),
                                GenderName = row[6].ToString(),
                                SectorName = row[7].ToString(),
                                LocationName = row[8].ToString(),
                                MenagerId = int.Parse(row[9].ToString()),
                            };
                            
                            userList.Add(r);
                        }
                        return userList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        
        public UserDTO GetUserById(int userId)
        {
            UserDTO result = new UserDTO();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_UsersById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            UserDTO r = new UserDTO
                            {
                                UserId = int.Parse(row[0].ToString()),
                                FullName = row[1].ToString(),
                                Date = DateTime.Parse(row[2].ToString()),
                                IDNumber = int.Parse(row[3].ToString()),
                                Jmbg = long.Parse(row[4].ToString()),
                                PhoneNumber = row[5].ToString(),
                                GenderName = row[6].ToString(),
                                SectorName = row[7].ToString(),
                                LocationName = row[8].ToString(),
                                MenagerId = int.Parse(row[9].ToString())
                            };
                            result=r;
                        }
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int AddUser(User user)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_User";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", user.Date);
                        cmd.Parameters.AddWithValue("@IDNumber", user.IDNumber);
                        cmd.Parameters.AddWithValue("@JMBG", user.Jmbg);
                        cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                        cmd.Parameters.AddWithValue("@GenderId", user.GenderId);
                        cmd.Parameters.AddWithValue("@SectorId", user.SectorId);
                        cmd.Parameters.AddWithValue("@LocationId", user.LocationId);
                        cmd.Parameters.AddWithValue("@MenagerId", user.MenagerId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            user.UserId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user.UserId;
        }

        public int AddSector(Sector sector)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_Sector";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", sector.Name);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            sector.SectorId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return sector.SectorId;
        }

        public int AddLocation(Location location)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_Location";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", location.Name);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            location.LocationId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return location.LocationId;
        }

        public int UpdateUser(User user)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Update_User";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.UserId);
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", user.Date);
                        cmd.Parameters.AddWithValue("@IDNumber", user.IDNumber);
                        cmd.Parameters.AddWithValue("@JMBG", user.Jmbg);
                        cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                        cmd.Parameters.AddWithValue("@GenderId", user.GenderId);
                        cmd.Parameters.AddWithValue("@SectorId", user.SectorId);
                        cmd.Parameters.AddWithValue("@LocationId", user.LocationId);
                        cmd.Parameters.AddWithValue("@MenagerId", user.MenagerId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            user.UserId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user.UserId;
        }

        public void DeleteUser(int userId)
        {            
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete_User";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        SqlDataReader reader = cmd.ExecuteReader();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());                    
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool CheckSectorName(string sectorName)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_SectorName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SectorName", sectorName);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool CheckJmbg(long jmbg)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_JMBG";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JMBG", jmbg);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
