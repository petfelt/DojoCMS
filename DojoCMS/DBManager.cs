using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace DojoCMS
{

    class DBManager
    {
      
        public  DbContext GetUserDBContext(string appDBName)
        {
            using (DbContext _context = new BloggingContextFactory(appDBName).Create())
            {
                return _context;
            }
        }


    }


}