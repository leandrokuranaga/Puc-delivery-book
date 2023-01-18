using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace deliverybook.Infra.Interfaces
{
    public interface IExternalService
    {
        Task<string> ExecutarAuthGetAsync(Uri uri, AuthenticationHeaderValue credentials);

        Task<string> ExecutarGetAsync(Uri uri);

        Task<string> ExecutarPostAsync(Uri uri, AuthenticationHeaderValue credentials);
    }
}