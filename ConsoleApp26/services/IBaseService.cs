namespace ConsoleApp26.services
{
    public interface IBaseService<T>
    {
        List<T> GetAllBlogs();
        T GetById(int id);
        int CreateBlog(T data);
        string UserEdit(int id);
        string UserDelete(int id);
    }
}
