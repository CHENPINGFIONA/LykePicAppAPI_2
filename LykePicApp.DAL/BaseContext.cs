using LykePicApp.Model;
using System.Data.Entity;

namespace LykePicApp.DAL
{
    public class BaseContext : DbContext
    {
        public BaseContext()
        : base("LykePicAppConn")
        {
        }
    }
}
