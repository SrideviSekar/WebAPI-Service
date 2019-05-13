using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLayer.Constants
{
    public static class StringConstant
    {
        public const string ConnectionString = "Data Source=DOTNET;Initial Catalog=MFRP;Integrated Security=True";

        public const string GetAllUsers = "GetAllUsers";

        public const string SaveUser = "SaveUser";

        public const string Updateuser = "Updateuser";

        public const string DeleteUser = "DeleteUser";

        public const string GetAllProjects = "GetAllProjects";

        public const string SaveProject = "SaveProject";

        public const string UpdateProject = "UpdateProject";

        public const string DeleteProject = "DeleteProject";

        public const string GetAllTasks = "GetAllTasks";

        public const string SaveTask = "SaveTask";

        public const string UpdateTask = "UpdateTask";

        public const string CompleteTask = "Complete";

    }
}
