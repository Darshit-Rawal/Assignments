using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repository
{
    public class Article
    {
        public virtual DateTime GetPublicationDate(int articleId)
        {
            throw new NotImplementedException();
        }

        public virtual int GetTotalArticles(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
