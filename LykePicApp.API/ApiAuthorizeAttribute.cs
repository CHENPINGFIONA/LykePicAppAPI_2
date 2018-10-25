using System.Web.Http.Controllers;

namespace System.Web.Http
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class ApiAuthAttribute : AuthorizeAttribute
    {
        private string funcName;

        public ApiAuthAttribute(string funcName)
        {
            this.funcName = funcName;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }
}