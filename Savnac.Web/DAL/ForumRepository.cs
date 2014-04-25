using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Savnac.Web.Models;
using System.Data.SqlClient;
using System.Data;

namespace Savnac.Web.DAL
{
    public class ForumRepository : IForumRepository
    {
        public ForumModel GetBy(int id)
        {
            ForumModel post = new ForumModel();

            var sql = string.Format("SELECT * FROM Post WHERE PostId = '{0}'", id);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    post = new ForumModel()
                    {
                    };
                }
            }

            return post;
        }

        public ICollection<ForumModel> GetForumBy(int courseId)
        {
            ICollection<ForumModel> post = new List<ForumModel>();

            return post;
        }
 
    }

    
}