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

            var sql = string.Format("SELECT * FROM PostTable WHERE PostId = '{0}'", id);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    post = new ForumModel()
                    {
                        postId = (int)reader["postId"],
                        title = reader["postTitle"].ToString(),
                        content = reader["postContent"].ToString(),
                        datePosted = (DateTime)reader["postTime"],
                        courseId = (int)reader["courseId"],
                        userName = reader["userName"].ToString(),
                        isRead = (bool)reader["post_isRead"]
                    };
                }
            }

            return post;
        }

        public ICollection<ForumModel> GetForumBy(string user)
        {
            ICollection<ForumModel> post = new List<ForumModel>();


            var sql = string.Format("SELECT * FROM PostTable WHERE userName = '{0}' ORDER BY postTime DESC", user);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        post.Add(new ForumModel()
                        {
                            postId = (int)reader["postId"],
                            title = reader["postTitle"].ToString(),
                            content = reader["postContent"].ToString(),
                            datePosted = (DateTime)reader["postTime"],
                            courseId = (int)reader["courseId"],
                            userName = reader["userName"].ToString(),
                            isRead = (bool)reader["post_isRead"]
                        });
                    }
                }
            }

            return post;
        }

        public void MarkRead(int id)
        {
            var sql = string.Format("UPDATE PostTable SET post_isRead='true' WHERE postId='{0}'", id);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddPost(string user, string title, string content, int course)
        {
            var sql = string.Format("INSERT INTO PostTable (userName, postTitle, postContent, postTime, post_isRead, courseId) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", user, title, content, DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"), false, course);
            var connectionString = "Server=(local);Database=Savnac.Database;Trusted_Connection=True;";

            var command = new SqlCommand(sql, new SqlConnection(connectionString));

            using (var connection = command.Connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
 
    }

    
}