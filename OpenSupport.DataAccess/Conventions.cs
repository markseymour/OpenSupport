using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace OpenSupport.DataAccess
{
    public class Conventions
    {
        public class DefaultStringPropertyConvention : IPropertyConvention
        {
            public void Apply(IPropertyInstance instance)
            {
                instance.Length(100);
                instance.Nullable();
            }
        }
    }
}
