using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOLayer.Constants;

namespace DAOLayer.Model
{
    public class DataAccess
    {
        //******************user section *************************//
        /// <summary>
        /// get User list
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            string sp = StringConstant.GetAllUsers;

            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlconn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet dt = new DataSet();
                    da.Fill(dt);
                    return BindDataList<User>(dt.Tables[0]);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return null;
        }

        public static List<T> BindDataList<T>(DataTable dt)
        {
            List<string> columns = new List<string>();
            foreach (DataColumn dc in dt.Columns)
            {
                columns.Add(dc.ColumnName);
            }

            var fields = typeof(T).GetFields();
            var properties = typeof(T).GetProperties();

            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                var ob = Activator.CreateInstance<T>();

                foreach (var fieldInfo in fields)
                {
                    if (columns.Contains(fieldInfo.Name))
                    {
                        fieldInfo.SetValue(ob, dr[fieldInfo.Name]);
                    }
                }

                foreach (var propertyInfo in properties)
                {
                    if (columns.Contains(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(ob, dr[propertyInfo.Name]);
                    }
                }

                lst.Add(ob);
            }

            return lst;
        }

        /// <summary>
        /// save or Update user 
        /// </summary>
        /// <returns></returns>
        public static bool SaveOrUpdateUser(User user, bool IsFromUpdate = false)
        {
            string sp = IsFromUpdate ? StringConstant.Updateuser : StringConstant.SaveUser;
            var result = 0;
            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@EmployeeId", user.Employee_ID);
                command.CommandType = CommandType.StoredProcedure;
                try

                {
                    sqlconn.Open();
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return result > 0 ? true : false;
        }
        
        /// <summary>
        /// delete user 
        /// </summary>
        /// <returns></returns>
        public static bool DeleteUser(int userId)
        {
            string sp = StringConstant.DeleteUser;
            var result = 0;
            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.Parameters.AddWithValue("@user_ID", userId);
                command.CommandType = CommandType.StoredProcedure;
                try

                {
                    sqlconn.Open();
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return result > 0 ? true : false;
        }

        //************Project section*****************************//
        /// <summary>
        /// get Project list
        /// </summary>
        /// <returns></returns>
        public static List<Project> GetAllProject()
        {
            string sp = StringConstant.GetAllProjects;

            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlconn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet dt = new DataSet();
                    da.Fill(dt);
                    return BindDataList<Project>(dt.Tables[0]);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return null;
        }

        /// <summary>
        /// save or Update Project 
        /// </summary>
        /// <returns></returns>
        public static bool SaveOrUpdateProject(Project project, bool IsFromUpdate = false)
        {
            string sp = IsFromUpdate ? StringConstant.UpdateProject : StringConstant.SaveProject;
            var result = 0;
            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.Parameters.AddWithValue("@Project", project.ProjectName);
                command.Parameters.AddWithValue("@StartDate", project.StartDate);
                command.Parameters.AddWithValue("@EndDate", project.EndDate);
                command.Parameters.AddWithValue("@Priority", project.Priority);
                if (!IsFromUpdate)
                {
                    command.Parameters.AddWithValue("@UserId", project.Manager);
                }
                command.CommandType = CommandType.StoredProcedure;
                try

                {
                    sqlconn.Open();
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// delete Projects 
        /// </summary>
        /// <returns></returns>
        public static bool Deleteproject(int projectId)
        {
            string sp = StringConstant.DeleteProject;
            var result = 0;
            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.Parameters.AddWithValue("@Project_ID", projectId);
                command.CommandType = CommandType.StoredProcedure;
                try

                {
                    sqlconn.Open();
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return result > 0 ? true : false;
        }


        //**********************Task Section************************//
        /// <summary>
        /// get Task list
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetAllTask()
        {
            string sp = StringConstant.GetAllTasks;
            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(sp, sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlconn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet dt = new DataSet();
                    da.Fill(dt);
                    return BindDataList<Task>(dt.Tables[0]);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return null;
        }

        /// <summary>
        /// save or Update Task 
        /// </summary>
        /// <returns></returns>
        public static bool SaveOrUpdateTask(Task task, bool IsFromUpdate = false, bool IsFromComplete = false)
        {
            string sp = IsFromUpdate ? StringConstant.UpdateTask : StringConstant.SaveTask;
            var result = 0;
            using (var sqlconn = new SqlConnection(StringConstant.ConnectionString))
            {
                var command = new SqlCommand(IsFromComplete ? StringConstant.CompleteTask : sp, sqlconn);
                if (IsFromComplete)
                {
                    command.Parameters.AddWithValue("@TaskId", task.Task_ID);
                    command.Parameters.AddWithValue("@Status", task.Status);
                }
                else
                {
                    if (IsFromUpdate)
                    {
                        command.Parameters.AddWithValue("@TaskId", task.Task_ID);
                    }

                    command.Parameters.AddWithValue("@TaskName", task.TaskName);
                    command.Parameters.AddWithValue("@Priority", task.Priority);
                    command.Parameters.AddWithValue("@StartDate", task.Start_Date);
                    command.Parameters.AddWithValue("@EndDate", task.End_Date);
                    if (!IsFromUpdate)
                    {
                        command.Parameters.AddWithValue("@ProjectId", task.Project_ID);
                        command.Parameters.AddWithValue("@ParentId", task.Parent_ID);
                        command.Parameters.AddWithValue("@UserId", task.User_ID);
                    }
                }

                command.CommandType = CommandType.StoredProcedure;
                try

                {
                    sqlconn.Open();
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return result > 0 ? true : false;
        }

    }
}
