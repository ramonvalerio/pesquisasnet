using System.Collections;

namespace PesquisasNet.Infra.Interfaces.AWS
{
    public interface ISESService
    {
        void EnviarEmail(IList destinos, string subject, string body);
    }
}
