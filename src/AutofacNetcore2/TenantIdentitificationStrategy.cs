using System;
using System.Linq;
using Autofac.Multitenant;
using Microsoft.AspNetCore.Http;

namespace AutofacNetcore2
{
    public class TenantIdentitificationStrategy : ITenantIdentificationStrategy
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public static readonly string[] TenantIds =
        {
            "tenantId1", "tenantId2"
        };

        public TenantIdentitificationStrategy(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool TryIdentifyTenant(out object tenantId)
        {
            tenantId = httpContextAccessor.HttpContext.Request.Headers["tenantId"];

            var tenantIdStringed = tenantId.ToString();

            return !string.IsNullOrWhiteSpace(tenantIdStringed) &&
                   TenantIdentitificationStrategy.TenantIds.Contains(tenantIdStringed,
                       StringComparer.InvariantCultureIgnoreCase);
        }
    }
}