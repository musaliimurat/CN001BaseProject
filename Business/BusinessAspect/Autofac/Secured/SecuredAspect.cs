using Castle.DynamicProxy;
using Core.Extensions;
using Core.Helpers.Interceptors;
using Core.Helpers.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspect.Autofac.Secured
{
    public class SecuredAspect : MethodInterception
    {
        //depedency inversion
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredAspect(string role)
        {
            
            _roles = role.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor?.HttpContext?.User.ClaimRoles();
            //1 - Admin, moderator
            // - superAdmin, masterAdmin
            foreach (var roleClaim in _roles)
            {
                if (roleClaims!.Contains(roleClaim))
                {
                    return;
                }

            }
            throw new Exception("Bu emeliyyati yerine yetirmeye icazeniz yoxdur");
        }
    }
}
