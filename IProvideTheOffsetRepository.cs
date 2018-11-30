using System;
using System.Linq;
using System.Reflection;
using Machine.Specifications;
using Dolittle.Runtime.Events.Relativity;

namespace Dolittle.Runtime.Events.Relativity.Specs
{
    public interface IProvideGeodesics
    {
        IGeodesics Build();
    }
}