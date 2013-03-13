using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using OpenSupport.Core.Models;

namespace OpenSupport.DataAccess
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().Any(t => type.Namespace != null && (t == typeof(IEntity) && type.Namespace.Contains("Core.Model")));
        }
    }
}
