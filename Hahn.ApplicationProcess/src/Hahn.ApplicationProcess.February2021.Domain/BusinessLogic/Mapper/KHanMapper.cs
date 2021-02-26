using AgileObjects.AgileMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.KHanMapper
{
    public interface IKHanMapper
    {
        public X MapToANew<T, X>(T source);
    }

    public class KHanMapper : IKHanMapper
    {
        public IMapper mapper { get; private set; }

        public KHanMapper()
        {
            mapper = Mapper.CreateNew();
            ConfigureMapper();

        }

        public X MapToANew<T, X>(T source) => mapper.Map(source).ToANew<X>();

        protected void ConfigureMapper()
        {
            //mapper.WhenMapping.UseConfigurations.From<EmployeeMapperConfigurations>();
        }

    }
}
