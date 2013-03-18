using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace OpenSupport.DataAccess
{
    public class Conventions
    {
        public class DefaultStringPropertyConvention : IPropertyConvention
        {
            public void Apply(IPropertyInstance instance)
            {
                instance.Nullable();
            }
        }

        public class StringColumnLengthConvention : IPropertyConvention, IPropertyConventionAcceptance
        {
            public void Apply(IPropertyInstance instance)
            {
                instance.Length(10000);
            }

            public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
            {
                criteria.Expect(x => x.Type == typeof(string)).Expect(x => x.Length == 0);
            }
        }
    }
}
