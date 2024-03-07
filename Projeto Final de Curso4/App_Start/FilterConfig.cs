using System.Web;
using System.Web.Mvc;

namespace Projeto_Final_de_Curso4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
