using ConsoleApp26.helpers;
using ConsoleApp26.models;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp26.services
{
    internal class userservice : IBaseService<T>
    {
       
        public int CreateBlog(Blog data)
        {
            string query = $"INSERT INTO blogs VALUES (N'{data.title}', N'{data.description}',N'{data.usersId} )";
            return SqlHelper.Exec(query);
        }

        public List<Blog> GetAllBlogs()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM blogs");
            List<Blog> list = new List<Blog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blog
                {
                    id = (int)row["id"],
                    title = (string)row["title"],
                    description = (string)row["description"],
                    usersId = (int)row["usersId"]
                });
            }
            return list;
        }

        public Blog GetById(int id)
        {
            string query = $"SELECT * FROM blogs WHERE Id = {id}";
            DataTable dt = SqlHelper.GetDatas(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Blog
                {
                    id = (int)row["id"],
                    title = (string)row["title"],
                    description = (string)row["description"],
                    usersId = (int)row["usersId"]
                };
            }
            else
            {
                return null; 
            }
        }

        public string UserDelete(int id)
        {
            string deleteBlogsQuery = $"DELETE FROM blogs WHERE usersId = {id}";
            SqlHelper.Exec(deleteBlogsQuery);
            string deleteUserQuery = $"DELETE FROM users WHERE Id = {id}";
            int result = SqlHelper.Exec(deleteUserQuery);
            if (result > 0)
            {
                return "İstifadəçi uğurla silindi!";
            }
            else
            {
                return "İstifadəçini silmək mümkün olmadı.";
            }
        }

        public string UserEdit(int id)
        {
            string nname = Console.ReadLine();
            string nsurname= Console.ReadLine(); 
            int nid= Convert.ToInt32(Console.ReadLine());
            string query = $"UPDATE users SET name = N'{nname}', surname = N'{nsurname}' WHERE Id = {nid}";
            int result = SqlHelper.Exec(query);

            if (result > 0)
            {
                return "İstifadəçi məlumatları uğurla yeniləndi!";
            }
            else
            {
                return "Məlumatları yeniləmək mümkün olmadı.";
            }
        }
    }
}
